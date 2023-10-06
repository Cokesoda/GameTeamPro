using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    MeshRenderer meshRender;
    public bool playerCheck = false;    //장난감상자 주위에 플레이어 충돌이 감지되면 true
    public float intensity = 0;

    private void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (playerCheck)        //충돌이 감지되면 쉐이더 색상을 노란색으로 바꾸고 빛남
        {
            meshRender.material.SetColor("_Color", new Color(1, 1, 0, 1));
            meshRender.material.SetFloat("_Intensity", intensity);
        }
        else
        {
            meshRender.material.SetColor("_Color", new Color(0, 0, 0, 1));
            meshRender.material.SetFloat("_Intensity", 0);
        }
    }

}
