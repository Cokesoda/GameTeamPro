using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy1FSM : MonoBehaviour
{
    [SerializeField]
    private GameObject item; // 적 파괴시 생성할 아이템 프리팹

    [SerializeField]
    private int count;  // 적 파괴시 생성할 아이템 갯수

    public GameObject player;
    NavMeshAgent nMa;
    public GameObject bulletObj;
    public Transform shotPos;
    public Transform shotPos2;
    Animator legoAni;
    public Slider enemyHpSlider;
    int ranattack;

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
    public float enemyHealtime = 1.1f;       //적 복귀 후 회복시간 +0.1 (초)
    public float enemyHealing = 10;          //적 복귀 후 초당 회복량

    float targetTrackingdistance;
    Vector3 originalPos;                     //기존 생성위치 포지션 값
    Vector3 originalRot;                     //기본 생성위치 로테이션 값
    public float HPcurrentTime = 0;

    public EnemyState e_state;
    public enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Hit,
        Die,
        item,
    }

    
    void Start()
    {
        count = 5;
        nMa = GetComponent<NavMeshAgent>();
        //player = GameObject.FindGameObjectWithTag("Player");//메인 캐릭터 Tag 변경 *중요
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
        if (isHit)
        {
            e_state = EnemyState.Hit;
        }
        if(enemyHp <= 0)
        {
            e_state = EnemyState.Die;
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
            case EnemyState.item:
                State_item();
                break;
        }
    }

    

    void State_Idle()
    {
        //print("Idle");
        //플레이어가 공격거리에 들어온 경우
        if(targetTrackingdistance < enemyAttackDistance)
        {
            e_state = EnemyState.Attack;
        }
        else if(targetTrackingdistance < enemyFindDistance &&
            targetTrackingdistance > enemyAttackDistance)
        //플레이어가 인식거리에 들어온 경우
        {
            Vector3 targetDir = player.transform.position - transform.position;
            targetDir.y = 0;
            transform.rotation = Quaternion.LookRotation(targetDir);
            e_state = EnemyState.Move;
            //print("Idle > Move");
        }
        /*else if (isHit == true)
        {
            //print("Hit!");
            e_state = EnemyState.Hit;
        }*/
        else if (HPcurrentTime >= enemyHealtime && enemyHp < enemyMaxHp)
        {
            enemyHp += 10;
            HPcurrentTime = 0;
        }
        else
        {
            legoAni.SetTrigger("Lego_Idle");
        }
    }
    void State_Move()
    {
        //print("Move");
        legoAni.SetTrigger("Lego_Walking");
        nMa.SetDestination(player.transform.position);
        nMa.stoppingDistance = enemyAttackDistance - 0.09f;
        //공격거리-0.09 까지 가서 멈춤
        Vector3 targetDir = player.transform.position - transform.position;
        targetDir.y = 0;
        transform.rotation = Quaternion.LookRotation(targetDir);
        if (targetTrackingdistance < enemyAttackDistance)
            //플레이어가 공격거리내에 들어온 경우
        {
            //print("Move > Attack");
            e_state = EnemyState.Attack;
        }
        else if (isHit == true)
        {
            //print("Hit!");
            e_state = EnemyState.Hit;
            isHit = false;
        }
        //초기 위치에서 벗어난 경우
        else if(Vector3.Distance(originalPos, transform.position) > enemyReturnDistance)
            //이동중 복귀거리 이상 이동한 경우
        {
            nMa.stoppingDistance = 0;
            //print("Move > Return");
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
        if (isHit == true)
        {
            //print("Hit!");
            e_state = EnemyState.Hit;
            isHit = false;
        }
        //현재거리 / 공격거리 / 인식거리
        else if (targetTrackingdistance < enemyAttackDistance)
        {
            legoAni.SetTrigger("Lego_Attack");
            legoAni.SetBool("Lego_canAttack", true);

            ranattack = UnityEngine.Random.Range(1, 3);
            legoAni.SetInteger("ranAttack",ranattack);
            //print("공격");
            yield return new WaitForSeconds(enemyAttackspeed);
        }
        //공격거리 / 현재거리 / 인식거리
        else if (targetTrackingdistance > enemyAttackDistance && targetTrackingdistance < enemyFindDistance)
        {
            legoAni.SetBool("Lego_canAttack", false);
            e_state = EnemyState.Move;
        }
        //공격거리 / 인식거리 / 현재거리
        else if(targetTrackingdistance > enemyFindDistance)
        {
            legoAni.SetBool("Lego_canAttack", false);
            e_state = EnemyState.Return;
        }
        yield break;
    }
    void State_Return()
    {
        if(Vector3.Distance(transform.position,originalPos) > 0.1f)
        {
            legoAni.SetTrigger("Lego_Walking");
            print("Return");
            nMa.isStopped = true;
            nMa.ResetPath();
            nMa.SetDestination(originalPos);
            nMa.stoppingDistance = 0;
        }
        //복귀후 idle상태로 변경조건                                                    
        else
        {
            nMa.isStopped = true;
            nMa.ResetPath();
            //print("Return > Idle");
            e_state = EnemyState.Idle;
        }
    }

    public void State_Hit()
    {
        if(enemyHp > 0)
        {
            isHit = false;
            StartCoroutine(HitState());
            e_state = EnemyState.Move;
        }
        else if(enemyHp < 0)
        {
            e_state = EnemyState.item;
        }
    }
    IEnumerator HitState()
    {
        legoAni.SetTrigger("Lego_Hit");
        print("Hit!" + enemyHp);
        yield return new WaitForSeconds(enemyHittime);
    }
    private void State_item()
    {
        if (count > 0)
        {
            new GameObject("item");

            count--;
        }
        if (count == 0)
        {
            e_state = EnemyState.Die;
        }
    }
    void State_Die()
    {
        legoAni.SetBool("Lego_Alive", false);
        Destroy(gameObject, enemyDietime);
    }
   
}
