using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    Rigidbody Lrb;
    LeFSM eFSM;
    LMstatus pStatus;

    // Start is called before the first frame update
    void Start()
    {
        Lrb = GetComponent<Rigidbody>();
        Lrb.AddRelativeForce(0, 100, 0);
    }
    void OnCollisionEnter(Collision collision) //�ٸ� ������Ʈ�� �浹���� ���
    {
        if (collision.collider.CompareTag("Player"))
        {
            //pStatus.playerHp =- eFSM.enemyAttackDamage; ������ ���� �� ����
            print(pStatus.playerHp);
        }
        
        Destroy(gameObject,0.5f);
    }
}
