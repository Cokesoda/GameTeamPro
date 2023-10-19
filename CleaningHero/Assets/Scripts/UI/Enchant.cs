using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enchant : MonoBehaviour
{
    public GameObject enchant;
    public GameObject Succese;
    public GameObject Fail;
    public Sprite thisImage;
    public Image weapon;
    public GameObject puzzle;
    public GameObject InGame;
    // Start is called before the first frame update
    void Start()
    {
        Succese.SetActive(false);
        Fail.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickEnchantStart()
    {
        enchant.SetActive(true);
        InGame.SetActive(false);
    }
    public void OnClickPuzzle()
    {
        puzzle.SetActive(true);
        InGame.SetActive(false);
    }
    public void OnClickWeapon1()
    {
        weapon.GetComponent<Image>().sprite = thisImage;
    }
    public void OnclickEnchant() 
    {
        //if ��ȭ��ᰡ ����ϴ�
        Succese.SetActive(true);
        //������ �ɷ�ġ ����

        //if ��ȭ��ᰡ �����ϴ�
        //Fail.SetActive(true);
    }

    public void OnclickCloseEnchant()
    {
        
        if (Succese.activeSelf == true)
        {
            Succese.SetActive(false);
        }

        if (Fail.activeSelf == true)
        {
            Fail.SetActive(false);
        }
    }
    public void OnClickCloseEnchant2()
    {
            enchant.SetActive(false);
            InGame.SetActive(true);
    }
}
