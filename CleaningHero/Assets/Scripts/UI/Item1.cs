using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1 : MonoBehaviour
{
    public GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (game.GetComponent<LMstatus>().playerHp < 10)
            {
                game.GetComponent<LMstatus>().playerHp += 1;
            }
        }
    }
}