using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lego : MonoBehaviour
{
    public bool playerCheck = false;
    public Text text;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerCheck)        //�浹�� �����Ǹ� ���̴� ������ ��������� �ٲٰ� ����
        {
            text.gameObject.SetActive(true);
            text.text =  " NPC�� �����Ϸ��� " + "<color=yellow>" + "(E)" + "</color>" + "Ű�� ��������.";
            gameManager.GetComponent<Reuslt>().clear= true;
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
}
