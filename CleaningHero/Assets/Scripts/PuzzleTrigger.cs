using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    public Puzzle puzzle;

    private void OnTriggerEnter(Collider other)     //플레이어가 감지범위내로 들어오면 ToyBox스크립트에 true값을 넘겨줌
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
