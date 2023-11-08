using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YBtrigger : MonoBehaviour
{
    public YB yb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            yb.playerCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            yb.playerCheck = false;
        }
    }
}
