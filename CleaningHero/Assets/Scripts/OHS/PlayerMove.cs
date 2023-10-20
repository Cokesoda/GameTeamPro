using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 2/40f;
    public float jumpPower = 4f;
    public bool isJumping = false;

    public GameObject hitEffect;
    public int hp = 20;

    CharacterController cc;

    float gravity = -3f;
    float yVelocity = 0;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        anim.SetFloat("MoveMotion", dir.magnitude);
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
        //if (isJumping){}

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }

    public void DamageAction(int damage)
    {
        hp -= damage;

        if (hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
    }

    IEnumerator PlayHitEffect()
    {
        hitEffect.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hitEffect.SetActive(false);
    }
}
