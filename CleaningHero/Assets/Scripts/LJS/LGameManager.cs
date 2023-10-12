using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGameManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoint;

    GameObject obj;
    void Start()
    {
        for(int i = 0; i < spawnPoint.Length; i++)
        obj = Instantiate(enemy, spawnPoint[i].position, spawnPoint[i].rotation);
    }
}
