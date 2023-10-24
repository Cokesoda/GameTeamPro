using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameState gState;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    public enum GameState
    {
        Ready,
        Run,
        Pause,
        GameOver
    }

    // Start is called before the first frame update
    void Start()
    {
        gState = GameState.Ready;
        StartCoroutine(ReadyToStart());
    }

    IEnumerator ReadyToStart()
    {
        //yield return new WaitForSeconds(2f);
        //gameText.text = "Go!";
        yield return new WaitForSeconds(0.5f);
        //gameLabel.SetActive(false);
        gState = GameState.Run;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
