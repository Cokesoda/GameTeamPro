using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBillboard : MonoBehaviour
{
    GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.LookAt(target.transform);
    }
}
