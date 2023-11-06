using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Bullet : MonoBehaviour
{
    Rigidbody Lrb;

    void Start()
    {
        Lrb = GetComponent<Rigidbody>();
        Lrb.AddRelativeForce(0, 0, 100);
    }
    void OnCollisionEnter(Collision collision) //다른 오브젝트와 충돌했을 경우
    {
        Destroy(gameObject, 0.5f);
    }
}
