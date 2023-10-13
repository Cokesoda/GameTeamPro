using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMstatus : MonoBehaviour
{
    public GameObject player;              //�÷��̾�
    public GameObject enemy;               //��

    public float enemyFindDistance = 1;    //�� �ν� �Ÿ�
    public float enemyAttackDistance = 1;  //�� ���� �Ÿ�
    public float enemyReturnDistance = 20; //�� ���� �Ÿ�

    public float enemyAttackDamage = 1;    //�� ���ݷ�
    public float enemyHp = 100;            //�� ü��
    public float enemyAttackspeed = 1;     //�� ���ݼӵ�(��)
    public float enemyMovespeed = 5;
    public float playerHp = 100;

    public float playerAttackDistance = 10;//�÷��̾� ���� �Ÿ�
    public float playerAttackDamage = 10;  //�÷��̾� ���� ������
    public float playerMoveSpeed = 10;     //�÷��̾� �̵� �ӵ�

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
