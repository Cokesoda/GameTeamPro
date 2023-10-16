using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeFSM : MonoBehaviour
{
    GameObject player;
    float targetTrackingdistance;
    /*public float findDistance = 10f;           //인식 범위 
    public float attackDistance = 1f;            //공격 범위
    public float returnDistance = 20f;         //이동반경 제한 범위*/       //스테이터스 변수 스크립트로 이동

    //public float attackDamage = 10;           //스테이터스 변수 스크립트로 이동

    Vector3 originalPos;                                //기존 생성위치 포지션 값

    NavMeshAgent nMa;

    GameObject GameManager;

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
    LMstatus statusScript;
    void Start()
    {
        statusScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LMstatus>();
        e_state = EnemyState.Idle;
<<<<<<< HEAD
        nMa = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");                                   //메인 캐릭터 오브젝트 이름 변경         *중요
        originalPos = transform.position;                                                                           //생성된 위치를 초기위치로 저장

=======
        nMa = GameObject.FindGameObjectWithTag("Enemy1").GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");//메인 캐릭터 오브젝트 이름 변경 *중요
        originalPos = transform.position;                   //생성된 위치를 초기위치로 저장
        nMa.speed = statusScript.enemyMovespeed;//몹 이동속도
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, statusScript.enemyFindDistance);
>>>>>>> parent of c5e3fa0 (10/14_16:36 Restore)
    }
    
    // Update is called once per frame
    void Update()
    {
        targetTrackingdistance = Vector3.Distance(player.transform.position,transform.position);
        print("몬스터와의 거리 = " + targetTrackingdistance);
        print("인식 위치=" + statusScript.enemyFindDistance);
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
                //state_Hit();
                break;
            case EnemyState.Die:
                //state_Die();
                break;
            case EnemyState.Finded:
                //state_Finded();
                break;
        }
    }
    void state_Idle()
    {
        print("Idle");
        //플레이어가 인식거리에 들어왔을 경우
                      //설정된 인식 거리      현재 거리
        if(statusScript.enemyFindDistance >= targetTrackingdistance)
        {
            e_state = EnemyState.Move;
            print("Idle > Move");
        }
        if(statusScript.enemyAttackDistance > targetTrackingdistance)
        {
            e_state = EnemyState.Attack;
        }
    }
    void state_Move()
    {
        print("Move");
        nMa.SetDestination(player.transform.position);
        //공격 거리에 들어왔을 경우
             //플레이어와의 거리       공격 거리
        if(targetTrackingdistance <= statusScript.enemyAttackDistance)
        {
            state_Attack();
            print("Move > Attack");
        }
        //초기 위치에서 벗어난 경우
                                     //초기 위치와의 거리            복귀 거리
        if (Vector3.Distance(originalPos, transform.position) <= statusScript.enemyReturnDistance
            && statusScript.enemyFindDistance < targetTrackingdistance)
        {
            e_state = EnemyState.Return;
            print("Move > Return");
        }
    }
    void state_Attack()
    {
        StartCoroutine(eAttack());
    }
    private IEnumerator eAttack()
    {
        print("Attack");
        yield return new WaitForSeconds(statusScript.enemyAttackspeed);
    }
    void state_Return()
    {
        print("Return");
        nMa.isStopped = true;
        nMa.ResetPath();
        nMa.SetDestination(originalPos);
        //복귀후 idle상태로 변경조건
                             //인식거리      플레이어와의 거리                                                          
        if(statusScript.enemyFindDistance > targetTrackingdistance
                                                                           //초기 위치   
            && Vector3.Distance(originalPos, transform.position)<=0.1)
        {
            e_state = EnemyState.Idle;
        }
    }
}
