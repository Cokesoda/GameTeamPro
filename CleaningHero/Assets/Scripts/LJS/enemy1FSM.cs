using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy1FSM : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nMa;
    public GameObject bulletObj;
    public Transform shotPos;
    public Transform shotPos2;
    GameObject playerStatus;
    LMstatus xLMstatus;
    Animator legoAni;

    //LMstatus statusScript;
    [Range(5, 0.1f)]
    public float enemyFindDistance = 0.5f;   //적 인식 거리
    [Range(5, 0.1f)]
    public float enemyAttackDistance = 1;    //적 공격 거리
    [Range(5, 0.1f)]
    public float enemyReturnDistance = 1.5f; //적 복귀 거리

    public float enemyAttackDamage = 1;      //적 공격력
    public float enemyHp = 100;              //적 체력
    public float enemyAttackspeed = 0.01f;   //적 공격 속도(초)
    [Range(1,0.1f)]
    public float enemyMovespeed = 5;         //적 이동 속도
    public float enemyHittime = 2f;          //적 피격 시간(초)
    public float enemyDietime = 2f;          //적 죽는 시간(초)

    float targetTrackingdistance;
    Vector3 originalPos;                     //기존 생성위치 포지션 값

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
        playerStatus = GameObject.Find("GameManager");
        xLMstatus = playerStatus.GetComponent<LMstatus>();
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
        print(xLMstatus.playerHp);
        targetTrackingdistance = Vector3.Distance(player.transform.position,transform.position);
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
        if(targetTrackingdistance < enemyFindDistance)
            //플레이어가 인식거리에 들어온 경우
        {
            transform.LookAt(player.transform);
            e_state = EnemyState.Move;
            print("Idle > Move");
        }
    }
    void state_Move()
    {
        legoAni.SetTrigger("Lego_Walking");
        nMa.SetDestination(player.transform.position);
        nMa.stoppingDistance = enemyAttackDistance - 0.09f;
        //공격거리의 -0.09까지 가서 멈춤
        transform.LookAt(player.transform);
        if (targetTrackingdistance < enemyAttackDistance)
            //플레이어가 공격거리내에 들어온 경우
        {
            print("Move > Attack");
            canAttack = true;
            e_state = EnemyState.Attack;
        }
        //초기 위치에서 벗어난 경우
        if(Vector3.Distance(originalPos, transform.position) > enemyReturnDistance)
            //이동중 복귀거리 이상 이동한 경우
        {
            canAttack = false;
            nMa.stoppingDistance = 0.001f;
            print("Move > Return");
            e_state = EnemyState.Return;
        }
    }
    void state_Attack()
    {
        transform.LookAt(player.transform);
        StartCoroutine(eAttack());                                      //공격 애니메이션추가
    }
    IEnumerator eAttack()
    {
        if (canAttack)//공격 가능한 경우
        {
            legoAni.SetInteger("ranAttack",UnityEngine.Random.Range(1, 3));
            canAttack = false;
            Instantiate(bulletObj,shotPos.position,shotPos.rotation);
            
            yield return new WaitForSeconds(enemyAttackspeed);
            if (targetTrackingdistance < enemyAttackDistance)
            {
                //공격()
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

        //복귀후 idle상태로 변경조건                                                    
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
        if(enemyHp > 0)
        {
            StartCoroutine(hitstate());
            e_state = EnemyState.Move;
        }
        else
        {
            e_state = EnemyState.Die;
        }
    }
    IEnumerator hitstate()
    {
        //AnimationPlay(피격);
        yield return new WaitForSeconds(enemyHittime);
        e_state = EnemyState.Move;
    }
    private void state_Die()
    {
        //AnimationPlay(죽음);
        StartCoroutine(EnemyDiestate());
    }
    IEnumerator EnemyDiestate()
    {
        
        yield return new WaitForSeconds(enemyDietime);
        Destroy(gameObject);
    }

}
