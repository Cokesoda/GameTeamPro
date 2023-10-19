using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class JigsawPuzzle : MonoBehaviour
{
    public GameObject puzzlePosSet;
    public GameObject puzzlePieceSet;
    public string[] pos = new string [4];
    public string[] piece = new string[4];
    public GameObject puzzle;
    public GameObject Clear;
    public GameObject Messege;
    // Start is called before the first frame update
    void Start()
    {
        Clear.SetActive(false);
        for (int i = 0; i < 4; i++)
        {
            pos[i] = puzzlePieceSet.transform.GetChild(i).gameObject.name;
        }
        Messege.SetActive(false);
}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
                if (puzzlePosSet.transform.GetChild(i).childCount > 0)
                {
                    piece[i] = puzzlePosSet.transform.GetChild(i).GetChild(0).gameObject.name;
                }
        }

        if (pos.SequenceEqual(piece))
        {
            Clear.SetActive(true);
        }
    }
    public void OnclicClear()
    {
        Clear.SetActive(false);
        Messege.SetActive(true);
    }
}
