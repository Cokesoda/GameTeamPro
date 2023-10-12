using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorTest : MonoBehaviour
{
    float h, v;
    public float speed;
    Vector3 dir;

    CharacterController controll;

    private void Start()
    {
        controll = GetComponent<CharacterController>();
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        dir = new Vector3(h, 0, v) * speed;

        controll.SimpleMove(dir);
    }
}
