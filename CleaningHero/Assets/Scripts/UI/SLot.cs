using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLot : MonoBehaviour
{
   
    public GameObject item;  // ȹ���� ������
    public int itemCount; // ȹ���� �������� ����
    public Image itemImage;

    [SerializeField]
    private Text text_count;
    [SerializeField]
    private GameObject go_CountImage;
    
    private void SetCLolor(float _alpha)
    { 
    
    }
}
