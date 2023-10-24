using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    enemy2FSM enemyStatus;
    GameObject playerStatus;
    LMstatus xLMstatus;
    string colliderName;
    
    Rigidbody Lrb;

    void Start()
    {
        playerStatus = GameObject.Find("GameManager");
        xLMstatus = playerStatus.GetComponent<LMstatus>();
        enemyStatus = enemy.GetComponent<enemy2FSM>();
        Lrb = GetComponent<Rigidbody>();
        Lrb.AddRelativeForce(0, 100, 0);
    }
    void OnCollisionEnter(Collision collision) //다른 오브젝트와 충돌했을 경우
    {
        colliderName = collision.collider.name;
        if (colliderName == "Player")
        {
            xLMstatus.playerHp -= enemyStatus.enemyAttackDamage;
        }
        Destroy(gameObject,0.5f);
    }
}
