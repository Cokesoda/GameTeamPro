using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    MeshRenderer meshRender;
    public bool playerCheck = false;    //�峭������ ������ �÷��̾� �浹�� �����Ǹ� true
    public float intensity = 0;

    private void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (playerCheck)        //�浹�� �����Ǹ� ���̴� ������ ��������� �ٲٰ� ����
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
