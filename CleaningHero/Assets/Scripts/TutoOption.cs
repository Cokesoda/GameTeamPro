using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutoOption : MonoBehaviour
{
    public GameObject inGame;
    public GameObject gameOption;
    public GameObject keySet;
    public AudioSource bgm;
    public AudioSource em;
    public Slider bgmBar;
    public Slider emBar;
    public GameObject Inven;
    public enum GameState   ///test
    { 
    Ready,
    Run,
    Pause,
    Gameover
    }
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        gameOption.SetActive(false);
        keySet.SetActive(false);
        Inven.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Inven.activeSelf == false)
            {
                if (gameOption.activeSelf == true)
                {
                    if (keySet.activeSelf == true)
                    {
                        keySet.SetActive(false);
                    }
                    else
                    {
                        gameOption.SetActive(false);
                        inGame.SetActive(true);
                    }
                }
                else
                {
                    gameOption.SetActive(true);
                    inGame.SetActive(false);
                }
            }
            else 
            {
                Inven.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inven.SetActive(true);
        }
        bgm.volume = bgmBar.value;
        em.volume = emBar.value;
    }
    public void OnClickOption()
    {
        gameOption.SetActive(true);
        Time.timeScale = 0f;
        inGame.SetActive(false);
    }
    public void CloseOptionWindow()
    {
        gameOption.SetActive(false);
        inGame.SetActive(true);
    }
    public void OnClickQuitGame()
    {
        Application.Quit();
    }
    public void OnClickResumeGame()
    {
        gameOption.SetActive(false);
        Time.timeScale = 1.0f;
        inGame.SetActive(true);
    }

    public void OnClicFullScreen()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
    }

    public void OnClickWindowed()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }
    public void OnClickKeySet()
    {
        keySet.SetActive(true);
    }

    public void OnclickCloseInven()
    {
        Inven.SetActive(false);
    }
}
