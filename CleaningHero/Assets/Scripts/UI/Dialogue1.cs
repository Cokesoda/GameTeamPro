using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class sysnobsys2
{
    [TextArea]
    public string dialog;
    public GameObject Imagee;
    public Text text;
    
}
public class Dialogue1 : MonoBehaviour
{
    private GameObject DB;

    private GameObject Image;

    private Text text;

    public sysnobsys[] dialogue;

    public GameObject DB_T;
    public GameObject Image_T;

    public GameObject Btn_N;
    public GameObject Btn_Y;
    public GameObject NoCanvas;
    public GameObject YesCanvas;

    private bool isDialogue = false;
    public bool NextScene = false;
    private int count;

    void Start()
    {
        Btn_N.SetActive(false);
        Btn_Y.SetActive(false);
        DB_T.SetActive(false);
        Image_T.SetActive(false);
        NoCanvas.SetActive(false);
        YesCanvas.SetActive(false);

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
                Btn_N.SetActive(true);
                Btn_Y.SetActive(true);
                }
        }
    }
    public void OnClickBtn_N()
    {
        NoCanvas.SetActive(true);
    }
    public void OnClickBtn_Y()
    {
        YesCanvas.SetActive(true);
    }
    public void OnClickBtn_No_X()
    {
        NoCanvas.SetActive(false);
    }
    public void OnClickBtn_Y_Next()
    {
        NextScene = true;
    }
}
