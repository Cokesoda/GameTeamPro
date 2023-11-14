using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YBtrigger : MonoBehaviour
{
    YB yb;

    ActionController ac;
    public GameObject text;

    private void Start()
    {
        ac = GameObject.Find("Player_Dummy").GetComponent<ActionController>();
        yb = GameObject.Find("Player_Dummy").GetComponent<YB>();
        text.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ac.pickupActivated = true;
            text.SetActive(true);
            text.GetComponent<Text>().text = GameObject.Find("YB").transform.GetComponent<ItemPickUp>().item.itemName + " È¹µæ " + "<color=yellow>" + "(E)" + "</color>";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ac.pickupActivated = false;
            text.SetActive(false);
        }
    }
}
