using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HP : MonoBehaviour
{
    public GameObject hp10;
    public GameObject hp1;
    public GameManager game;

    public Sprite a0;
    public Sprite a1;
    public Sprite a2;
    public Sprite a3;
    public Sprite a4;
    public Sprite a5;
    public Sprite a6;
    public Sprite a7;
    public Sprite a8;
    public Sprite a9;
    // Start is called before the first frame update
    void Start()
    {
        hp10.GetComponent<Image>().sprite = a1;
        hp1.GetComponent<Image>().sprite = a0;
    }

    // Update is called once per frame
    void Update()
    {
        if (game.GetComponent<LMstatus>().playerHp == 10)
        {
            hp10.GetComponent<Image>().sprite = a1;
            hp1.GetComponent<Image>().sprite = a0;
        }
        else if (game.GetComponent<LMstatus>().playerHp == 9)
        {
            hp10.GetComponent<Image>().sprite = a0;
            hp1.GetComponent<Image>().sprite = a9;
        }
        else if (game.GetComponent<LMstatus>().playerHp == 8)
        {
            hp10.GetComponent<Image>().sprite = a0;
            hp1.GetComponent<Image>().sprite = a8;
        }
        else if (game.GetComponent<LMstatus>().playerHp == 7)
        {
            hp10.GetComponent<Image>().sprite = a0;
            hp1.GetComponent<Image>().sprite = a7;
        }
        else if (game.GetComponent<LMstatus>().playerHp == 6)
        {
            hp10.GetComponent<Image>().sprite = a0;
            hp1.GetComponent<Image>().sprite = a6;
        }
        else if (game.GetComponent<LMstatus>().playerHp == 5)
        {
            hp10.GetComponent<Image>().sprite = a0;
            hp1.GetComponent<Image>().sprite = a5;
        }
        else if (game.GetComponent<LMstatus>().playerHp == 4)
        {
            hp10.GetComponent<Image>().sprite = a0;
            hp1.GetComponent<Image>().sprite = a4;
        }
        else if (game.GetComponent<LMstatus>().playerHp == 3)
        {
            hp10.GetComponent<Image>().sprite = a0;
            hp1.GetComponent<Image>().sprite = a3;
        }
        else if (game.GetComponent<LMstatus>().playerHp == 2)
        {
            hp10.GetComponent<Image>().sprite = a0;
            hp1.GetComponent<Image>().sprite = a2;
        }
        else if (game.GetComponent<LMstatus>().playerHp == 1)
        {
            hp10.GetComponent<Image>().sprite = a0;
            hp1.GetComponent<Image>().sprite = a1;
        }
        else if (game.GetComponent<LMstatus>().playerHp == 0)
        {
            hp10.GetComponent<Image>().sprite = a0;
            hp1.GetComponent<Image>().sprite = a0;
        }
    }
}
