using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range;  // 아이템 습득이 가능한 최대 거리

    public bool pickupActivated = false;  // 아이템 습득 가능할시 True 

    private RaycastHit hitInfo;  // 충돌체 정보 저장

    public GameObject Item;

    [SerializeField]
    private LayerMask layerMask;  // 특정 레이어를 가진 오브젝트에 대해서만 습득할 수 있어야 한다.

    [SerializeField]
    private Text actionText;  // 행동을 보여 줄 텍스트
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
            Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 했습니다.");  // 인벤토리 넣기
            theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item,1);
            Destroy(hitInfo.transform.gameObject);
            pickupActivated = false;
        }
    }
}