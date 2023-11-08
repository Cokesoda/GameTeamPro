using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reuslt : MonoBehaviour
{
    public bool clear;
    public GameObject result;
    // Start is called before the first frame update
    void Start()
    {
        clear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (clear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                result.SetActive(true);
            }
        }
    }
}
