using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTuto : MonoBehaviour
{
    public GameObject HP;
    public GameObject Item;
    public GameObject time;
    public GameObject InGame;
    public GameObject Key;
    public GameObject Inventory;
    void Start()
    {
       
        HP.SetActive(true);
        Item.SetActive(false);
        time.SetActive(false);
        Key.SetActive(false);
        InGame.SetActive(false);
        //Inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (HP.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                HP.SetActive(false);
                Item.SetActive(true);
            }
        }
        else if (Item.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Item.SetActive(false);
                time.SetActive(true);
            }
        }
        
        else if (time.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                time.SetActive(false);
                Key.SetActive(true);
            }
        }
        else if (Key.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Key.SetActive(false);
                InGame.SetActive(true);
                
            }
        }
    }
}
