using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayermovwe : MonoBehaviour
{
    public float playermovespeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Vertical");
        float v = Input.GetAxisRaw("Horizontal");
        Vector3 Move = new (v, 0, h);
        transform.Translate(Move * Time.deltaTime);
    }
}
