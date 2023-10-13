using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeFSM : MonoBehaviour
{
    GameObject player;
    float targetTrackingdistance;

    Vector3 originalPos;                                //���� ������ġ ������ ��

    NavMeshAgent nMa;

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
        nMa = GameObject.FindGameObjectWithTag("Enemy1").GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");//���� ĳ���� ������Ʈ �̸� ���� *�߿�
        originalPos = transform.position;                   //������ ��ġ�� �ʱ���ġ�� ����
        nMa.speed = statusScript.enemyMovespeed;//�� �̵��ӵ�
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, statusScript.enemyFindDistance);
    }
    // Update is called once per frame
    void Update()
    {
        
        targetTrackingdistance = Vector3.Distance(player.transform.position,transform.position);
        print("���Ϳ��� �Ÿ� = " + targetTrackingdistance);
        print("�ν� ��ġ=" + statusScript.enemyFindDistance);
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
        }
    }
    void state_Idle()
    {
        print("Idle");
        //Animation(IdlePlay);  //�ִϸ��̼� Idle���� �Ϸ��� �߰�

        //�÷��̾ �νİŸ��� ������ ���
                      //������ �ν� �Ÿ�      ���� �Ÿ�
        if(statusScript.enemyFindDistance >= targetTrackingdistance)
        {
            e_state = EnemyState.Move;
            print("Idle > Move");
        }
        //�÷��̾ ���ݹ����� ��������
        if(statusScript.enemyAttackDistance > targetTrackingdistance)
        {
            e_state = EnemyState.Attack;
        }
    }
    void state_Move()
    {
        print("Move");
        nMa.SetDestination(player.transform.position);
        nMa.stoppingDistance = statusScript.enemyAttackDistance - 0.09f;
        //���� �Ÿ��� ������ ���
             //�÷��̾���� �Ÿ�       ���� �Ÿ�
        if(targetTrackingdistance <= statusScript.enemyAttackDistance)
        {
            state_Attack();
            print("Move > Attack");
        }
        //�ʱ� ��ġ���� ��� ���
                                     //�ʱ� ��ġ���� �Ÿ�            ���� �Ÿ�
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
        //AnimationPlay(Attack);
        yield return new WaitForSeconds(statusScript.enemyAttackspeed);
    }
    void state_Return()
    {
        print("Return");
        nMa.isStopped = true;
        nMa.ResetPath();
        nMa.SetDestination(originalPos);
        //������ idle���·� ��������
                             //�νİŸ�      �÷��̾���� �Ÿ�                                                          
        if(statusScript.enemyFindDistance > targetTrackingdistance
                                                                           //�ʱ� ��ġ   
            && Vector3.Distance(originalPos, transform.position)<=0.1)
        {
            e_state = EnemyState.Idle;
        }
    }
}
