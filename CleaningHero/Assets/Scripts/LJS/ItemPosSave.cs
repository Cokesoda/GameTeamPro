using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPosSave : MonoBehaviour
{
    public static GameObject enemyLItem;
    public static GameObject enemyRItem;
    public static GameObject DropItem;

    public bool e1Die = false;
    public bool e2Die = false;

    /*private void Start()
    {
        GameObject enemyLItem = new GameObject();
        GameObject enemyRItem = new GameObject();
    }*/
    void Update()
    {
        if (e1Die)
        {
            Instantiate(DropItem, enemyLItem.transform.position, enemyLItem.transform.rotation);
            e1Die = false;
        }
        if (e2Die)
        {
            Instantiate(DropItem, enemyRItem.transform.position, enemyRItem.transform.rotation);
            e2Die = false;
        }
    }
}
