using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Bullet : MonoBehaviour
{
    public GameObject enemy;
    Enemy2FSM enemyStatus;
    GameObject playerStatus;
    LMstatus xLMstatus;
    string colliderName;
    
    Rigidbody Lrb;

    void Start()
    {
        playerStatus = GameObject.Find("GameManager");
        xLMstatus = playerStatus.GetComponent<LMstatus>();
        enemyStatus = enemy.GetComponent<Enemy2FSM>();
        Lrb = GetComponent<Rigidbody>();
        Lrb.AddRelativeForce(0, 0, 100);
    }
    void OnCollisionEnter(Collision collision) //�ٸ� ������Ʈ�� �浹���� ���
    {
        colliderName = collision.collider.name;
        if (colliderName == "Player")
        {
            xLMstatus.playerHp -= enemyStatus.enemyAttackDamage;
        }
        Destroy(gameObject,0.5f);
    }
}
