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
    Vector3 originalPos;  //���� ������ġ ������ ��

    public float currentTime = 0;

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
        player = GameObject.FindGameObjectWithTag("Player");//���� ĳ���� ������Ʈ �̸� ���� *�߿�
        originalPos = transform.position;                   //������ ��ġ�� �ʱ���ġ�� ����
        nMa.speed = statusScript.enemyMovespeed;//�� �̵��ӵ�
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
        print("���Ϳ��� �Ÿ� = " + targetTrackingdistance);
        print("�ʱ� ��ġ���� �Ÿ� = " + Vector3.Distance(originalPos, transform.position));
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
            //�÷��̾ �νİŸ��� ���� ���
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
        //���ݰŸ��� -0.09���� ���� ����

        if(targetTrackingdistance < statusScript.enemyAttackDistance)
            //�÷��̾ ���ݰŸ����� ���� ���
        {
            state_Attack();
            print("Move > Attack");
        }
        //�ʱ� ��ġ���� ��� ���
        if (Vector3.Distance(originalPos, transform.position) > statusScript.enemyReturnDistance)
            //�̵��� ���ͰŸ� �̻� �̵��� ���
        {
            e_state = EnemyState.Return;
            print("Move > Return");
        }
    }
    void state_Attack()
    {
        if (currentTime > statusScript.enemyAttackspeed)
        {
            print("����");
            currentTime = 0;
        }
        else
        {
            e_state = EnemyState.Move;
            currentTime = 0;
        }
        //AnimationPlay(Attack);
    }
    void state_Return()
    {
        print("Return");
        nMa.isStopped = true;
        nMa.ResetPath();
        nMa.SetDestination(originalPos);
        //������ idle���·� ��������                                                    
        if(Vector3.Distance(transform.position,originalPos)<=0.01f)
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
