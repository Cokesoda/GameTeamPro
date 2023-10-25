using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Hit : MonoBehaviour
{
    public GameObject bulletObj;
    public Transform shotPos1;
    public Transform shotPos2;
    public void LeftBlockHit()
    {
        Instantiate(bulletObj, shotPos1.position, shotPos1.rotation);
    }
    public void RightBlockHit()
    {
        Instantiate(bulletObj, shotPos2.position, shotPos2.rotation);
    }
}
