using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeFSM : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nMa;
    public GameObject bulletObj;
    public Transform shotPos;

    //LMstatus statusScript;
    [Range(5, 0.1f)]
    public float enemyFindDistance = 0.5f;   //�� �ν� �Ÿ�
    [Range(5, 0.1f)]
    public float enemyAttackDistance = 1;    //�� ���� �Ÿ�
    [Range(5, 0.1f)]
    public float enemyReturnDistance = 1.5f; //�� ���� �Ÿ�

    public float enemyAttackDamage = 1;      //�� ���ݷ�
    public float enemyHp = 100;              //�� ü��
    public float enemyAttackspeed = 0.01f;   //�� ���ݼӵ�(��)
    [Range(1,0.1f)]
    public float enemyMovespeed = 5;         //�� �̵��ӵ�

    float targetTrackingdistance;
    Vector3 originalPos;                     //���� ������ġ ������ ��

    public float currentTime = 0;
    bool canAttack = false;

    EnemyState e_state;
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Hit,
        Die,
        Finded
    }

    void Start()
    {
        //statusScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LMstatus>();
        nMa = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");//���� ĳ���� ������Ʈ �̸� ���� *�߿�
        originalPos = transform.position;                   //������ ��ġ�� �ʱ���ġ�� ����
        nMa.speed = enemyMovespeed;            //�� �̵��ӵ�
        e_state = EnemyState.Idle;
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
        targetTrackingdistance = Vector3.Distance(player.transform.position,transform.position);
        /*print("���Ϳ��� �Ÿ� = " + targetTrackingdistance);
        print("�ʱ� ��ġ���� �Ÿ� = " + Vector3.Distance(originalPos, transform.position));*/
        currentTime += Time.deltaTime;

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
        print("Idle");
        //Animation(IdlePlay);
        if(targetTrackingdistance < enemyFindDistance)
            //�÷��̾ �νİŸ��� ���� ���
        {
            transform.LookAt(player.transform);
            e_state = EnemyState.Move;
            print("Idle > Move");
        }
    }
    void state_Move()
    {
        print("Move");
        nMa.SetDestination(player.transform.position);
        nMa.stoppingDistance = enemyAttackDistance - 0.09f;
        //���ݰŸ��� -0.09���� ���� ����

        if(targetTrackingdistance < enemyAttackDistance)
            //�÷��̾ ���ݰŸ����� ���� ���
        {
            print("Move > Attack");
            canAttack = true;
            e_state = EnemyState.Attack;
        }
        //�ʱ� ��ġ���� ��� ���
        if(Vector3.Distance(originalPos, transform.position) > enemyReturnDistance)
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
        StartCoroutine(eAttack());
        //AnimationPlay(Attack);
    }
    IEnumerator eAttack()
    {
        if (canAttack)//���� ������ ���
        {
            canAttack = false;
            /*statusScript.playerHp = -statusScript.enemyAttackDamage;*/
            transform.LookAt(player.transform);
            Instantiate(bulletObj,shotPos.position,shotPos.rotation);
            yield return new WaitForSeconds(enemyAttackspeed);
            if (targetTrackingdistance < enemyAttackDistance)
            {
                canAttack = true;
            }
            else if(targetTrackingdistance > enemyAttackDistance)
            {
                print("Attack > Move");
                e_state = EnemyState.Move;
            }
        }
    }
    void state_Return()
    {
        print(originalPos);
        print("Return");
        nMa.isStopped = true;
        nMa.ResetPath();
        nMa.SetDestination(originalPos);

        //������ idle���·� ��������                                                    
        if(Vector3.Distance(transform.position,originalPos)<0.2f)
        {
            nMa.isStopped = true;
            nMa.ResetPath();
            print("Return > Idle");
            e_state = EnemyState.Idle;
        }
    }

    private void state_Hit()
    {

    }
    private void state_Die()
    {

    }

}
