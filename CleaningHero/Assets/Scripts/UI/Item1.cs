using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item1 : MonoBehaviour
{
    public GameObject game;
    Inventory inven;
    SLot[] slot;
    public Item _item;
    string count;

    // Start is called before the first frame update
    void Start()
    {
        inven = game.GetComponent<Inventory>();
        slot = inven.go_SlotsParent.GetComponentsInChildren<SLot>();
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < slot.Length; i++)
            {
                if(slot[i].item == _item)
                {
                    if (slot[i].itemCount > 0)
                    {
                        if (game.GetComponent<LMstatus>().playerHp < 10)
                        {
                            game.GetComponent<LMstatus>().playerHp += 1;
                            slot[i].UseItem();
                        }
                    }
                }
            }
        }
    }
}
