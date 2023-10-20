using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScene : MonoBehaviour
{
    public int SceneNumber;
    public GameObject StorySceneManager;
    // Start is called before the first frame update
    void Start()
    {
        SceneNumber = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (StorySceneManager.GetComponent<Dialogue>().NextScene == true)
        {
            SceneManager.LoadScene(SceneNumber+1);
        }

    }
}
