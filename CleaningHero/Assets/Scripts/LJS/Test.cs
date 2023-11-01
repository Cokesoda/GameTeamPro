using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    NavMeshAgent namg;
    public GameObject player;
    private void Start()
    {
        namg = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        namg.SetDestination(player.transform.position);
    }
}
