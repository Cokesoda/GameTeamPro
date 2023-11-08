using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YB : MonoBehaviour
{
    public bool playerCheck = false;
    public Text text;
    private RaycastHit hitInfo;
    public ActionController ac;
    void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerCheck)        //충돌이 감지되면 쉐이더 색상을 노란색으로 바꾸고 빛남
        {
            ac.pickupActivated = true;
            text.gameObject.SetActive(true);
            text.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 " + "<color=yellow>" + "(E)" + "</color>";
        }
        else
        {
            ac.pickupActivated = false;
            text.gameObject.SetActive(false);
        }
    }
}
