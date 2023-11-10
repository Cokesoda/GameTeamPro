using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool invectoryActivated = false;  // 인벤토리 활성화 여부. true가 되면 카메라 움직임과 다른 입력을 막을 것이다.

    public GameObject go_SlotsParent;  // Slot들의 부모인 Grid Setting 
    public GameObject go_SlotsParent1;  // Slot들의 부모인 Grid Setting 

    private SLot[] slots;
    private SLot1[] slots1;// 슬롯들 배열
    public int _count = 1;

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<SLot>();
        slots1 = go_SlotsParent1.GetComponentsInChildren<SLot1>();
    }

    public void AcquireItem(Item _item, int _count)
    {
        if(Item.ItemType.wrapon != _item.itemType && Item.ItemType.ETC != _item.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)  // null 이라면 slots[i].item.itemName 할 때 런타임 에러 나서
                {
                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
        if (Item.ItemType.wrapon != _item.itemType && Item.ItemType.Used != _item.itemType)
        {
            for (int i = 0; i < slots1.Length; i++)
            {
                if (slots1[i].item != null)  // null 이라면 slots[i].item.itemName 할 때 런타임 에러 나서
                {
                    if (slots1[i].item.itemName == _item.itemName)
                    {
                        slots1[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < slots1.Length; i++)
        {
            if (slots1[i].item == null)
            {
                slots1[i].AddItem(_item, _count);
                return;
            }
        }
    }
}