using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpPower = 1f;
    public bool isJumping = false;

    CharacterController cc;

    float gravity = -3f;
    float yVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        dir = Camera.main.transform.TransformDirection(dir);

        if (isJumping && cc.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;
            yVelocity = 0;
            
        }
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = jumpPower / 15;
            isJumping = true;
        }
        if (isJumping)
        {
            yVelocity += gravity * Time.deltaTime;
        }

        dir.y = yVelocity;
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}
