using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMstatus : MonoBehaviour
{
    public GameObject player;              //플레이어
    public GameObject enemy;               //적

    public float enemyFindDistance = 1;    //적 인식 거리
    public float enemyAttackDistance = 1;  //적 공격 거리
    public float enemyReturnDistance = 20; //적 복귀 거리

    public float enemyAttackDamage = 1;    //적 공격력
    public float enemyHp = 100;            //적 체력
    public float enemyAttackspeed = 1;     //적 공격속도(초)
    public float enemyMovespeed = 5;
    public float playerHp = 100;

    public float playerAttackDistance = 10;//플레이어 공격 거리
    public float playerAttackDamage = 10;  //플레이어 공격 데미지
    public float playerMoveSpeed = 10;     //플레이어 이동 속도

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
