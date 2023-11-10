using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range;  // ������ ������ ������ �ִ� �Ÿ�

    public bool pickupActivated = false;  // ������ ���� �����ҽ� True 

    private RaycastHit hitInfo;  // �浹ü ���� ����

    public GameObject Item;

    [SerializeField]
    private LayerMask layerMask;  // Ư�� ���̾ ���� ������Ʈ�� ���ؼ��� ������ �� �־�� �Ѵ�.

    [SerializeField]
    private Text actionText;  // �ൿ�� ���� �� �ؽ�Ʈ
    float distance;

    [SerializeField]
    private Inventory theInventory;

    public Vector3 vec;

    
    private void Start()
    {
    }
    public void Update()
    {
        Physics.Raycast((transform.position + vec), Camera.main.transform.forward, out hitInfo);
        Debug.DrawRay((transform.position + vec), Camera.main.transform.forward, Color.green);
        if (Input.GetKeyDown(KeyCode.E) && hitInfo.transform.gameObject != null && hitInfo.transform.CompareTag("Item"))
        {
            CanPickUp();
        }
    }
    private void CanPickUp()
    {
        if(pickupActivated)
        {
            Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� �߽��ϴ�.");  // �κ��丮 �ֱ�
            theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item,1);
            Destroy(hitInfo.transform.gameObject);
            pickupActivated = false;
        }
    }
}