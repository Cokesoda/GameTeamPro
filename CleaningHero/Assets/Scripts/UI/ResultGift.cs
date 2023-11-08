using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultGift : MonoBehaviour
{
    [SerializeField]
    private Inventory theInventory;

    public Item item1;
    public Item item2;
    public int count1 = 10;
    public int count2 = 1;

    // Start is called before the first frame update
    public void OnClcikOK()
    {
        theInventory.AcquireItem(item1,count1);
        theInventory.AcquireItem(item2, count2);
    }
}
