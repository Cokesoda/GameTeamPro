using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTuto : MonoBehaviour
{
    public GameObject HP;
    public GameObject Weapon;
    public GameObject Item;
    public GameObject bullet;
    public GameObject Time;
    public GameObject InGame;
    public GameObject Key;
    void Start()
    {
        HP.SetActive(true);
        Weapon.SetActive(false);
        Item.SetActive(false);
        bullet.SetActive(false);
        Time.SetActive(false);
        Key.SetActive(false);
        InGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (HP.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                HP.SetActive(false);
                Weapon.SetActive(true);
            }
        }
        else if (Weapon.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Weapon.SetActive(false);
                Item.SetActive(true);
            }
        }
        else if (Item.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Item.SetActive(false);
                bullet.SetActive(true);
            }
        }
        else if (bullet.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                bullet.SetActive(false);
                Time.SetActive(true);
            }
        }
        else if (Time.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Time.SetActive(false);
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
