using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class sysnobsys
{
    [TextArea]
    public string dialog;
    public GameObject Db;
    public GameObject Imagee;
    public Text text;
    
}
public class Dialogue : MonoBehaviour
{
    private GameObject DB;

    private GameObject Image;

    private Text text;

    public sysnobsys[] dialogue;

    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;

    public GameObject DB_S;
    public GameObject DB_T;
    public GameObject DB_E;
    public GameObject DB_M;
    public GameObject DB_Mo;

    public GameObject Image_s;
    public GameObject Image_T;
    public GameObject Image_E;
    public GameObject Image_M;
    public GameObject Image_Mo;

    private bool isDialogue = false;
    public bool NextScene = false;
    private int count;

    void Start()
    {
        bg2.SetActive(false);
        bg3.SetActive(false);

        DB_S.SetActive(false);
        DB_T.SetActive(false);
        DB_E.SetActive(false);
        DB_M.SetActive(false);
        DB_Mo.SetActive(false);

        Image_s.SetActive(false);
        Image_T.SetActive(false);
        Image_E.SetActive(false);
        Image_M.SetActive(false);
        Image_Mo.SetActive(false);

        isDialogue = true;
        count = 0;
        NextDialogue(count);
        NextScene = false;
    }

    private void NextDialogue(int count)
    {
        DB = dialogue[count].Db;

        DB.SetActive(true);

        text = dialogue[count].text;

        text.text = dialogue[count].dialog;

        Image = dialogue[count].Imagee;
        Image.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogue == true) //활성화가 되었을 때만 대사가 진행되도록
        {
            if (Input.anyKeyDown)
            {
                if (count == 28)
                {
                    bg1.SetActive(false);
                    bg2.SetActive(true);
                }
                if (count > 28)
                {
                    bg2.SetActive(false);
                    bg3.SetActive(true);
                }
                            
                //대화의 끝을 알아야함.
                if (count < dialogue.Length)
                {
                    DB.SetActive(false);
                    count++;
                    NextDialogue(count); 
                }
                else
                {
                    isDialogue = false;
                    NextScene = true;
                }
            }
        }
    }
}
