using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject gamemanager;
    public GameObject firePosition;
    //public GameObject wBulletEffect;
    public bool isHit = false;

    public GameObject ShotEx;
    public ParticleSystem HitEx;
    public GameObject ExOriginalPos;
    //ParticleSystem ps;
    Animator anim;
    LMstatus playerstatus;
    public GameObject enemy1Tag;
    public GameObject enemy2Tag;

    // Start is called before the first frame update
    void Start()
    {
        //ps = wBulletEffect.GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();
        playerstatus = gamemanager.GetComponent<LMstatus>();
    }
    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(firePosition.transform.position, Camera.main.transform.forward, Color.red);
        isHit = false;
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<PlayerSoundManager>().AttackSound.Play();
            if (anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Attack");
                anim.SetFloat("AttackSpeed", 2f);
            }
            //Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            //ShotEx.transform.position = firePosition.transform.position;
            //ShotEx.transform.rotation = firePosition.transform.rotation;
            
            RaycastHit hitInfo = new RaycastHit();
            if(Physics.Raycast(firePosition.transform.position, Camera.main.transform.forward, out hitInfo, playerstatus.playerAttackDistance))
            {
                Debug.DrawRay(firePosition.transform.position, Camera.main.transform.forward,Color.red);
                if (hitInfo.collider.tag == enemy1Tag.tag)
                {
                    //isHit = true;
                    Debug.Log("Hit target = Enemy1");
                    Enemy1FSM e1FSM = hitInfo.collider.GetComponent<Enemy1FSM>();
                    e1FSM.enemyHp -= playerstatus.playerAttackDamage;
                    e1FSM.e1isHit = true;
                }
                else if(hitInfo.collider.tag == enemy2Tag.tag)
                {
                    Debug.Log("Hit target = Enemy2");
                    Enemy2FSM e2FSM = hitInfo.collider.GetComponent<Enemy2FSM>();
                    e2FSM.enemyHp -= playerstatus.playerAttackDamage;
                    e2FSM.e2isHit = true;
                }
                else
                {
                    //transform.TransformDirection(Vector3.forward)
                    Debug.DrawRay(firePosition.transform.position, Camera.main.transform.forward * playerstatus.playerAttackDistance, Color.red);
                    //wBulletEffect.transform.position = hitInfo.point;
                    //wBulletEffect.transform.forward = hitInfo.normal;
                    //ps.Play();
                    //ps.Stop();
                    //Destroy(ps, 0.1f);
                    HitEx.transform.position = hitInfo.point;
                    HitEx.transform.forward = hitInfo.normal;
                    HitEx.Play();
                }
            }
        }
    }
}
