using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeFSM : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nMa;
    LMstatus statusScript;


    float targetTrackingdistance;
    Vector3 originalPos;  //기존 생성위치 포지션 값

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
        statusScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LMstatus>();
        nMa = GameObject.FindGameObjectWithTag("Enemy1").GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");//메인 캐릭터 오브젝트 이름 변경 *중요
        originalPos = transform.position;                   //생성된 위치를 초기위치로 저장
        nMa.speed = statusScript.enemyMovespeed;            //몹 이동속도
        e_state = EnemyState.Idle;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, statusScript.enemyFindDistance);
        Gizmos.DrawWireSphere(transform.position, statusScript.enemyAttackDistance);
        Gizmos.DrawWireSphere(transform.position, statusScript.enemyReturnDistance);
    }

    void Update()
    {
        targetTrackingdistance = Vector3.Distance(player.transform.position,transform.position);
        /*print("몬스터와의 거리 = " + targetTrackingdistance);
        print("초기 위치와의 거리 = " + Vector3.Distance(originalPos, transform.position));*/
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
        if(targetTrackingdistance < statusScript.enemyFindDistance)
            //플레이어가 인식거리에 들어온 경우
        {
            e_state = EnemyState.Move;
            print("Idle > Move");
        }
    }
    void state_Move()
    {
        print("Move");
        nMa.SetDestination(player.transform.position);
        nMa.stoppingDistance = statusScript.enemyAttackDistance - 0.09f;
        //공격거리의 -0.09까지 가서 멈춤

        if(targetTrackingdistance < statusScript.enemyAttackDistance)
            //플레이어가 공격거리내에 들어온 경우
        {
            print("Move > Attack");
            canAttack = true;
            e_state = EnemyState.Attack;
        }
        //초기 위치에서 벗어난 경우
        if(Vector3.Distance(originalPos, transform.position) > statusScript.enemyReturnDistance)
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
        StartCoroutine(eAttack());
        //AnimationPlay(Attack);
    }
    IEnumerator eAttack()
    {
        if (canAttack)//공격 가능한 경우
        {
            canAttack = false;
            statusScript.playerHp = -statusScript.enemyAttackDamage;
            print("Attack");
            yield return new WaitForSeconds(statusScript.enemyAttackspeed);
            if (targetTrackingdistance < statusScript.enemyAttackDistance)
            {
                canAttack = true;
            }
            else if(targetTrackingdistance > statusScript.enemyAttackDistance)
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

    }
    private void state_Die()
    {

    }

}
