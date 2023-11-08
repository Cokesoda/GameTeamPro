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
        if (playerCheck)        //충돌이 감지되면 쉐이더 색상을 노란색으로 바꾸고 빛남
        {
            text.gameObject.SetActive(true);
            text.text =  " NPC를 구출하려면 " + "<color=yellow>" + "(E)" + "</color>" + "키를 누르세요.";
            gameManager.GetComponent<Reuslt>().clear= true;
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
}
