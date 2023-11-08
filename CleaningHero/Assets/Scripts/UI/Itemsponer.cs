using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemsponer : MonoBehaviour
{
    public bool enemycheck = false;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Update()
    {
        if (enemycheck) 
        {
            for (int i = 0; i < 5; i++)
            {
                new GameObject("YB");
            }
        }
        
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy1"))
        {
            enemycheck = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("enemy1"))
        {
            enemycheck = false;
        }
    }
}
