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
        // 퍼즐을 먹는다면
        // i++;
        // q1.text = "퍼즐을 모아라 ( " + i + " / 4 )";

        // 무기가 바뀐다면
        //Q2.text = "< color = black>" + "열쇠를 모아라" + "</color>";
    }
}
