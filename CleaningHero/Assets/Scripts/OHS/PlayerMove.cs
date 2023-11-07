using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpPower = 4f;
    public bool isJumping = false;
    
    CharacterController cc;

    float gravity = -3f;
    float yVelocity = 0;

    Animator anim;

    private RaycastHit hitInfo;
    //private float range;
    //private bool pickupActivated = false;
    //private LayerMask layerMask;

    public GameObject gameManager;
    LMstatus playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = gameManager.GetComponent<LMstatus>();
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (HitManager.PlayerisHit == true)
        {
            StartCoroutine(PlayHitEffect());
        }*/
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        anim.SetFloat("MoveMotion", dir.magnitude);
        dir = Camera.main.transform.TransformDirection(dir);

        if (Input.GetKeyDown(KeyCode.F))
        {
            InteractionCtrl();
        }
        if (isJumping && cc.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;
            yVelocity = 0;
        }
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            /*
            if (anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Jump");
            }
            */
            yVelocity = jumpPower / 15;
            isJumping = true;
        }
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        cc.Move(dir * moveSpeed * (Time.deltaTime/2));
    }

    private void InteractionCtrl()
    {
        //if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo))
        {
            if (hitInfo.transform.tag == "ToyBox")
            {
                Interaction("ToyBox");
            }
            if (hitInfo.transform.tag == "Pillow")
            {
                Interaction("Pillow");
            }
            if (hitInfo.transform.tag == "Book")
            {
                Interaction("Book");
            }
        }
    }

    private void Interaction(string inter)
    {
        switch (inter)
        {
            case "ToyBox":
                Debug.Log("======================= " + inter);
                break;
            case "Pillow":
                Debug.Log("======================= " + inter);
                break;
            case "Book":
                Debug.Log("======================= " + inter);
                break;
            default:
                break;

        }
    }
    
    IEnumerator PlayHitEffect()
    {
        anim.SetTrigger("Damage");
        playerStatus.playerHp -= 1;
        yield return new WaitForSeconds(0.3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Lego_block" || other.name == "enemy2Bullet")
        {
            print("Bullet_Hit");
            StartCoroutine(PlayHitEffect());
        }
    }
}
