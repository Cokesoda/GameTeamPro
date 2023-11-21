using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryMusic : MonoBehaviour
{
    public GameObject BGMObject;
    [SerializeField]
    AudioSource BackGround;
    
    void Awake()
    {
        BackGround = this.GetComponent<AudioSource>();
        /*if (BackGround.isPlaying) return;
        else
        {*/
            BackGround.Play();
            DontDestroyOnLoad(BGMObject);
        //}
    }
}
