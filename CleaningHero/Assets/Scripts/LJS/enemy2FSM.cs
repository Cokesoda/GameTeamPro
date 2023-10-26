using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy2FSM : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nMa;
    public GameObject bulletObj;
    public Transform shotPos;
    GameObject playerStatus;
    Animator legoAni;
    public Slider enemyHpSlider;

    public bool isHit = false;


    [Range(5, 0.1f)]
    public float enemyFindDistance = 0.5f;   //�� �ν� �Ÿ�
    [Range(5, 0.1f)]
    public float enemyAttackDistance = 1;    //�� ���� �Ÿ�
    [Range(5, 0.1f)]
    public float enemyReturnDistance = 1.5f; //�� ���� �Ÿ�

    public float enemyAttackDamage = 1;      //�� ���ݷ�
    public float enemyHp = 100;              //�� ü��
    public float enemyMaxHp = 101;           //�� �ִ� ü�� + 1
    public float enemyAttackspeed = 0.01f;   //�� ���� �ӵ�(��)
    [Range(1, 0.1f)]
    public float enemyMovespeed = 5;         //�� �̵� �ӵ�
    public float enemyHittime = 2f;          //�� �ǰ� �ð�(��)
    public float enemyDietime = 2f;          //�� �״� �ð�(��)

    float targetTrackingdistance;
    Vector3 originalPos;                     //���� ������ġ ������ ��

    public float HPcurrentTime = 0;
    bool canAttack = false;

    EnemyState e_state;
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Hit,
        Die
    }


    void Start()
    {
        nMa = GetComponent<NavMeshAgent>();
        playerStatus = GameObject.Find("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");//���� ĳ���� Tag ���� *�߿�
        originalPos = transform.position;                   //������ ��ġ�� �ʱ���ġ�� ����
        nMa.speed = enemyMovespeed;                         //�� �̵��ӵ�
        e_state = EnemyState.Idle;
        legoAni = GetComponent<Animator>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyFindDistance);
        Gizmos.DrawWireSphere(transform.position, enemyAttackDistance);
        Gizmos.DrawWireSphere(transform.position, enemyReturnDistance);
    }

    void Update()
    {
        targetTrackingdistance = Vector3.Distance(player.transform.position, transform.position);
        HPcurrentTime += Time.deltaTime;
        if (HPcurrentTime >= 1.1)
        {
            HPcurrentTime = 0;
        }

        enemyHpSlider.value = enemyHp / enemyMaxHp;

        switch (e_state)
        {
            case EnemyState.Idle:
                state_Idle();
                break;
            case EnemyState.Move:
                state_Move();
                break;
            case EnemyState.Attack:
                state_Attack();
                break;
            case EnemyState.Return:
                state_Return();
                break;
            case EnemyState.Hit:
                state_Hit();
                break;
            case EnemyState.Die:
                state_Die();
                break;
        }
    }


    void state_Idle()
    {
        legoAni.SetTrigger("Lego_Idle");
        print("Idle");
        if (targetTrackingdistance < enemyFindDistance)
        //�÷��̾ �νİŸ��� ���� ���
        {
            Vector3 targetDir = player.transform.position - transform.position;
            targetDir.y = 0;
            transform.rotation = Quaternion.LookRotation(targetDir);
            e_state = EnemyState.Move;
            print("Idle > Move");
        }
        else if (isHit)
        {
            print("Hit!");
            e_state = EnemyState.Hit;
        }
        else
        {
            if (HPcurrentTime >= 1 && enemyHp < enemyMaxHp)
            {
                enemyHp += 10;
                HPcurrentTime = 0;
            }
        }
    }
    void state_Move()
    {
        legoAni.SetTrigger("Lego_Walking");
        nMa.SetDestination(player.transform.position);
        nMa.stoppingDistance = enemyAttackDistance - 0.09f;
        //���ݰŸ��� -0.09���� ���� ����
        Vector3 targetDir = player.transform.position - transform.position;
        targetDir.y = 0;
        transform.rotation = Quaternion.LookRotation(targetDir);
        if (targetTrackingdistance < enemyAttackDistance)
        //�÷��̾ ���ݰŸ����� ���� ���
        {
            print("Move > Attack");
            canAttack = true;
            e_state = EnemyState.Attack;
        }
        //�ʱ� ��ġ���� ��� ���
        else if (Vector3.Distance(originalPos, transform.position) > enemyReturnDistance)
        //�̵��� ���ͰŸ� �̻� �̵��� ���
        {
            canAttack = false;
            nMa.stoppingDistance = 0.001f;
            print("Move > Return");
            e_state = EnemyState.Return;
        }
    }

    void state_Attack()
    {
        Vector3 targetDir = player.transform.position - transform.position;
        targetDir.y = 0;
        transform.rotation = Quaternion.LookRotation(targetDir);
        StartCoroutine(eAttack());
    }
    IEnumerator eAttack()
    {
        if (canAttack)//���� ������ ���
        {
            int ranattack = UnityEngine.Random.Range(1, 3);
            legoAni.SetTrigger("Lego_Attack");
            legoAni.SetInteger("ranAttack", ranattack);
            canAttack = false;
            yield return new WaitForSeconds(enemyAttackspeed);
            //���� ������ ���� ���
            if (targetTrackingdistance < enemyAttackDistance)
            {
                canAttack = true;
            }
            //���� �������� ��� ���
            else if (targetTrackingdistance > enemyAttackDistance)
            {
                print("Attack > Move");
                canAttack = false;
                e_state = EnemyState.Move;
            }
        }
    }
    void state_Return()
    {
        legoAni.SetTrigger("Lego_Walking");
        print("Return");
        nMa.isStopped = true;
        nMa.ResetPath();
        nMa.SetDestination(originalPos);

        //������ idle���·� ��������                                                    
        if (Vector3.Distance(transform.position, originalPos) < 0.2f)
        {
            nMa.isStopped = true;
            nMa.ResetPath();
            print("Return > Idle");
            e_state = EnemyState.Idle;
        }
    }

    public void state_Hit()
    {
        if (enemyHp > 0)
        {
            StartCoroutine(hitState());
            e_state = EnemyState.Move;
        }
        else
        {
            e_state = EnemyState.Die;
        }
    }
    IEnumerator hitState()
    {
        legoAni.SetTrigger("Lego_Hit");
        yield return new WaitForSeconds(enemyHittime);
    }
    private void state_Die()
    {
        StartCoroutine(dieState());
    }
    IEnumerator dieState()
    {
        legoAni.SetTrigger("Lego_Die");
        yield return new WaitForSeconds(enemyDietime);
        Destroy(gameObject);
    }

}
