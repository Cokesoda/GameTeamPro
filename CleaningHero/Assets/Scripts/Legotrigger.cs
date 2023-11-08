using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legotrigger : MonoBehaviour
{
    public Lego lego;

    private void OnTriggerEnter(Collider other)     
    {
        if (other.CompareTag("Player"))
        {
            lego.playerCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lego.playerCheck = false;
        }
    }
}
