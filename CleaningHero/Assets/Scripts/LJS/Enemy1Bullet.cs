using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Bullet : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    Enemy1FSM enemyStatus;
    //GameObject playerStatus;
    string colliderName;
    PlayerMove playerMove;
    Rigidbody Lrb;

    float hitdamage;
    void Start()
    {
        //playerStatus = GameObject.Find("GameManager");
        enemyStatus = enemy.GetComponent<Enemy1FSM>();
        Lrb = GetComponent<Rigidbody>();
        Lrb.AddRelativeForce(0,-1,20);
        playerMove = GetComponent<PlayerMove>();
        hitdamage = enemyStatus.enemyAttackDamage;
    }
    void OnCollisionEnter(Collision collision) //�ٸ� ������Ʈ�� �浹���� ���
    {
        colliderName = collision.collider.tag;
        if (colliderName == "Player")
        {
            playerMove.DamageAction(hitdamage);
        }
        Destroy(gameObject, 0.5f);
    }
}
