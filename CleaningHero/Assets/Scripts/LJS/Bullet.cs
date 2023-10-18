using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject objBullet;
    public Transform mShotpos;
    GameObject Lobj;

    Rigidbody Lrb;

    // Start is called before the first frame update
    void Start()
    {
        Lobj = Instantiate(objBullet,mShotpos);
        Lrb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision) //다른 오브젝트와 충돌했을 경우
    {
        Destroy(Lobj);
    }
}
