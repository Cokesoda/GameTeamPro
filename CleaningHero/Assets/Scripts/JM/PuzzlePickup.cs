using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePickup : MonoBehaviour
{
    public Inventory theInventory;
    public GameObject puzzle_Item;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player"))
        {
            print("E");
            CanPickUp();
        }
    }

    private void CanPickUp()
    {
        theInventory.AcquireItem(puzzle_Item.transform.GetComponent<ItemPickUp>().item, 1);
        Destroy(transform.parent.gameObject);
        
    }
}
