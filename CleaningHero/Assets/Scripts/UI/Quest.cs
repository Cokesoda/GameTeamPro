using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Q1;
    public Text Q2;
    public GameObject Puzzle;
    Text q1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Q1.text = q1.text;

        // int i;
        // ������ �Դ´ٸ�
        // i++;
        // q1.text = "������ ��ƶ� ( " + i + " / 4 )";

        // ���Ⱑ �ٲ�ٸ�
        //Q2.text = "< color = black>" + "���踦 ��ƶ�" + "</color>";
    }
}
