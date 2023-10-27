using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy1FSM : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nMa;
    public GameObject bulletObj;
    public Transform shotPos;
    public Transform shotPos2;
    GameObject playerStatus;
    Animator legoAni;
    public Slider enemyHpSlider;

    public bool isHit = false;


    [Range(5, 0.1f)]
    public float enemyFindDistance = 0.5f;   //적 인식 거리
    [Range(5, 0.1f)]
    public float enemyAttackDistance = 1;    //적 공격 거리
    [Range(5, 0.1f)]
    public float enemyReturnDistance = 1.5f; //적 복귀 거리

    public float enemyAttackDamage = 1;      //적 공격력
    public float enemyHp = 100;              //적 체력
    public float enemyMaxHp = 101;           //적 최대 체력 + 1
    public float enemyAttackspeed = 0.01f;   //적 공격 속도(초)
    [Range(1,0.1f)]
    public float enemyMovespeed = 5;         //적 이동 속도
    public float enemyHittime = 2f;          //적 피격 시간(초)
    public float enemyDietime = 2f;          //적 죽는 시간(초)

    float targetTrackingdistance;
    Vector3 originalPos;                     //기존 생성위치 포지션 값

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
        player = GameObject.FindGameObjectWithTag("Player");//메인 캐릭터 Tag 변경 *중요
        originalPos = transform.position;                   //생성된 위치를 초기위치로 저장
        nMa.speed = enemyMovespeed;                         //몹 이동속도
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
        targetTrackingdistance = Vector3.Distance(player.transform.position,transform.position);
        HPcurrentTime += Time.deltaTime;
        if(HPcurrentTime >= 1.1)
        {
            HPcurrentTime = 0;
        }

        enemyHpSlider.value = enemyHp / enemyMaxHp;

        switch (e_state)
        {
            case EnemyState.Idle:
                State_Idle();
                break;
            case EnemyState.Move:
                State_Move();
                break;
            case EnemyState.Attack:
                State_Attack();
                break;
            case EnemyState.Return:
                State_Return();
                break;
            case EnemyState.Hit:
                State_Hit();
                break;
            case EnemyState.Die:
                State_Die();
                break;
        }
    }


    void State_Idle()
    {
        legoAni.SetTrigger("Lego_Idle");
        print("Idle");
        if(targetTrackingdistance < enemyFindDistance)
            //플레이어가 인식거리에 들어온 경우
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
            if(HPcurrentTime >= 1 && enemyHp < enemyMaxHp)
            {
                enemyHp += 10;
                HPcurrentTime = 0;
            }
        }
    }
    void State_Move()
    {
        legoAni.SetTrigger("Lego_Walking");
        nMa.SetDestination(player.transform.position);
        nMa.stoppingDistance = enemyAttackDistance - 0.09f;
        //공격거리의 -0.09까지 가서 멈춤
        Vector3 targetDir = player.transform.position - transform.position;
        targetDir.y = 0;
        transform.rotation = Quaternion.LookRotation(targetDir);
        if (targetTrackingdistance < enemyAttackDistance)
            //플레이어가 공격거리내에 들어온 경우
        {
            print("Move > Attack");
            canAttack = true;
            e_state = EnemyState.Attack;
        }
        //초기 위치에서 벗어난 경우
        else if(Vector3.Distance(originalPos, transform.position) > enemyReturnDistance)
            //이동중 복귀거리 이상 이동한 경우
        {
            canAttack = false;
            nMa.stoppingDistance = 0.001f;
            print("Move > Return");
            e_state = EnemyState.Return;
        }
    }
    
    void State_Attack()
    {
        Vector3 targetDir = player.transform.position - transform.position;
        targetDir.y = 0;
        transform.rotation = Quaternion.LookRotation(targetDir);
        StartCoroutine(EAttack());                                      
    }
    IEnumerator EAttack()
    {
        if (canAttack)//공격 가능한 경우
        {
            int ranattack = UnityEngine.Random.Range(1, 3);
            legoAni.SetTrigger("Lego_Attack");
            legoAni.SetInteger("ranAttack", ranattack);
            canAttack = false;
            yield return new WaitForSeconds(enemyAttackspeed);
            //공격 범위에 들어온 경우
            if (targetTrackingdistance < enemyAttackDistance)
            {
                canAttack = true;
            }
            //공격 범위에서 벗어난 경우
            else if(targetTrackingdistance > enemyAttackDistance)
            {
                print("Attack > Move");
                canAttack = false;
                e_state = EnemyState.Move;
            }
        }
    }
    void State_Return()
    {
        legoAni.SetTrigger("Lego_Walking");
        print("Return");
        nMa.isStopped = true;
        nMa.ResetPath();
        nMa.SetDestination(originalPos);

        //복귀후 idle상태로 변경조건                                                    
        if(Vector3.Distance(transform.position,originalPos)<0.2f)
        {
            nMa.isStopped = true;
            nMa.ResetPath();
            print("Return > Idle");
            e_state = EnemyState.Idle;
        }
    }

    public void State_Hit()
    {
        if(enemyHp > 0)
        {
            StartCoroutine(HitState());
            e_state = EnemyState.Move;
        }
        else
        {
            e_state = EnemyState.Die;
        }
    }
    IEnumerator HitState()
    {
        legoAni.SetTrigger("Lego_Hit");
        yield return new WaitForSeconds(enemyHittime);
    }
    private void State_Die()
    {
        StartCoroutine(DieState());
    }
    IEnumerator DieState()
    {
        legoAni.SetTrigger("Lego_Die");
        yield return new WaitForSeconds(enemyDietime);
        Destroy(gameObject);
    }

}
