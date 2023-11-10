using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    public PuzzleItem puzzle;

    private void OnTriggerEnter(Collider other)     //�÷��̾ ������������ ������ ToyBox��ũ��Ʈ�� true���� �Ѱ���
    {
        if (other.CompareTag("Player"))
        {
            puzzle.playerCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puzzle.playerCheck = false;
        }
    }
}
