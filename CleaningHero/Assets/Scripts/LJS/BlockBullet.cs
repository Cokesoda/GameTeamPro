using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBullet : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    enemy1FSM enemyStatus;
    GameObject playerStatus;
    LMstatus xLMstatus;
    string colliderName;

    Rigidbody Lrb;

    void Start()
    {
        playerStatus = GameObject.Find("GameManager");
        xLMstatus = playerStatus.GetComponent<LMstatus>();
        enemyStatus = enemy.GetComponent<enemy1FSM>();
        Lrb = GetComponent<Rigidbody>();
        Lrb.AddRelativeForce(-250, 0, 0);
    }
    void OnCollisionEnter(Collision collision) //�ٸ� ������Ʈ�� �浹���� ���
    {
        colliderName = collision.collider.name;
        if (colliderName == "Player")
        {
            xLMstatus.playerHp -= enemyStatus.enemyAttackDamage;
        }
        Destroy(gameObject, 0.5f);
    }
}
