using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public AudioSource AttackSound;
    public AudioSource HitSound;
    public AudioSource Heal1Sound;
    public void SAttackPlay()
    {
        AttackSound.Play();
    }
    public void SHitPlay()
    {
        HitSound.Play();
    }
    public void SHeal1Play()
    {
        Heal1Sound.Play();
    }
}
