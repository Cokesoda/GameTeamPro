using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLink : MonoBehaviour
{
    public GameObject Gun;
    private void Start()
    {
        Instantiate(Gun);
    }
    void Update()
    {
        Gun.transform.position = transform.position;
    }
}
