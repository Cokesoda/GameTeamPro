using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public GameObject gameOption;
    FullScreenMode ScreenMode;
    public AudioSource bgm;
    public AudioSource em;
    public Slider bgmBar;
    public Slider emBar;
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        gameOption.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameOption.activeSelf == true)
            {
                gameOption.SetActive(false);
            }
            else
            {
                gameOption.SetActive(true);
            }
        }
        bgm.volume = bgmBar.value;
        em.volume = emBar.value;
    }
    public void OnClickOption()
    {
        gameOption.SetActive(true);
    }
    public void CloseOptionWindow()
    {
        gameOption.SetActive(false);
    }
    public void OnClickQuitGame()
    {
        Application.Quit();
    }
    public void OnClickStartGame()
    {
          SceneManager.LoadScene(1);
    }

    public void OnClicFullScreen()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
    }

    public void OnClickWindowed()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }
}
