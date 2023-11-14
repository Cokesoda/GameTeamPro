using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messege : MonoBehaviour
{
    public GameObject ToT;
    public GameObject ToTNo;
    public GameObject ToTYes;
    public GameObject Result;

    public void OnClickYes()
    {
        ToTYes.SetActive(true);

    }
    public void OnClickYesBtn()
    {
        Result.SetActive(true);
        ToTYes.SetActive(false);
    }

    public void OnClickNo()
    {
        ToTNo.SetActive(true);
    }
    public void OnClickNoBtn()
    {
        ToTNo.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        ToTNo.SetActive(false);
        ToTYes.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            ToT.SetActive(false);
        }
    }
}
