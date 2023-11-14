using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutoOption2 : MonoBehaviour
{
    public GameObject inGame;
    public GameObject gameOption;
    public GameObject keySet;
    public AudioSource bgm;
    public AudioSource em;
    public Slider bgmBar;
    public Slider emBar;
    public GameObject Inven;
    public GameObject Result;
    public GameObject enchant;
    public GameObject Succese;
    public GameObject Fail;
    public GameObject puzzle;
    public int SceneNumber;
    public Inventory Theinventory;

    public Item ResultItem1;
    public Item ResultItem2;
    public Item ResultItem3;
    public Item ResultItem4;

    private RectTransform invenRec;

    public enum GameState   ///test
    { 
    Ready,
    Run,
    Pause,
    Gameover
    }
    // Start is called before the first frame update.

    private void Awake()
    {
        Time.timeScale = 1f;
        SceneNumber = SceneManager.GetActiveScene().buildIndex;
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        gameOption.SetActive(false);
        keySet.SetActive(false);
        //Inven.SetActive(false);
        invenRec = Inven.GetComponent<RectTransform>();
        invenRec.anchoredPosition = new Vector3(900, 0, 0);
        Result.SetActive(false);
        enchant.SetActive(false);
        puzzle.SetActive(false);
    }
    void Start()
    {
        Theinventory.AcquireItem(ResultItem1, 10);
        Theinventory.AcquireItem(ResultItem2, 1);
        Theinventory.AcquireItem(ResultItem3, 1);
        Theinventory.AcquireItem(ResultItem4, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enchant.activeSelf == false)
            {
                
                    if (gameOption.activeSelf == true)
                    {
                        if (keySet.activeSelf == true)
                        {
                            keySet.SetActive(false);
                        }
                        else if (puzzle.activeSelf == true)
                        {
                            puzzle.SetActive(false);
                        }
                        else
                        {
                            Time.timeScale = 1f;
                            gameOption.SetActive(false);
                            inGame.SetActive(true);
                        }
                    }
                    else
                    {
                        gameOption.SetActive(true);
                        inGame.SetActive(false);
                        //Time.timeScale = 0f;
                    }
                
                if(invenRec.anchoredPosition.x == 0)
                {
                    Time.timeScale = 1f;
                    inGame.SetActive(true);
                    invenRec.anchoredPosition = new Vector3(900, 0, 0);
                    //Inven.SetActive(false);
                }
            }
            else if (Succese.activeSelf == false && Fail.activeSelf == false)
            {
                Time.timeScale = 1f;
                enchant.SetActive(false);
                inGame.SetActive(true);
            }
            else if (Succese.activeSelf == true)
            {
                Succese.SetActive(false);
            }
            else if(Fail.activeSelf == true)
            {
                Fail.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            invenRec = Inven.GetComponent<RectTransform>();
            invenRec.anchoredPosition = new Vector3(0, 0, 0);
            inGame.SetActive(false);
        }
        if (Result.activeSelf == true)
        {
            inGame.SetActive(false);
        }

        bgm.volume = bgmBar.value;
        em.volume = emBar.value;
    }
    public void OnClickOption()
    {
        gameOption.SetActive(true);
        Time.timeScale = 0f;
        if (puzzle.activeSelf == true)
        {
            inGame.SetActive(false);
        }
    }
    public void CloseOptionWindow()
    {
        Time.timeScale = 1f;
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
        if (puzzle.activeSelf == false)
        {
            inGame.SetActive(true);
        }
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
        Time.timeScale = 1f;
        invenRec = Inven.GetComponent<RectTransform>();
        invenRec.anchoredPosition = new Vector3(900, 0, 0);
    }
    public void OnClickClear()
    {
        Time.timeScale = 0f;
        Result.SetActive(true);
    }
    public void OnClickResult()
    {
        Time.timeScale = 0f;
        Result.SetActive(false);
        
        SceneManager.LoadScene(SceneNumber + 1);
    }
}
