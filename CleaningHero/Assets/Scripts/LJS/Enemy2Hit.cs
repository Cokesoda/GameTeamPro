using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Hit : MonoBehaviour
{
    public Transform shotPos;
    public GameObject enemy2Bullet;
    GameObject e2AttackSound;

    public void enemy2CreateBullet()
    {
        Instantiate(enemy2Bullet, shotPos.position, shotPos.rotation);
        e2AttackSound = GameObject.Find("SoundE2Attack");
        e2AttackSound.GetComponent<AudioSource>().Play();
    }
}
