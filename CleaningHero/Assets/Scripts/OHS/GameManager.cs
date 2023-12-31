using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameState gState;

    PlayerMove player;

    public GameObject gameOption;
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
        player = GameObject.Find("Player_Dummy").GetComponent<PlayerMove>();
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(0.5f);
        //gameLabel.SetActive(false);
        gState = GameState.Run;
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.hp <= 0)
        //{
           // player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);

            //gameLabel.SetActive(true);
            //gameText.text = "Game Over";
            //gameText.color = new Color32(255, 0, 0, 255);
            //Transform.buttons = gameText.transform.GetChild(0);
            //buttons.gameObject.SetActive(true);

           // gState = GameState.GameOver;
      //  }
    }

    public void OpenOptionWindow()
    {
        gameOption.SetActive(true);
        Time.timeScale = 0f;
        gState = GameState.Pause;
    }
    public void CloseOptionWindow()
    {
        gameOption.SetActive(false);
        Time.timeScale = 1f;
        gState = GameState.Run;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
