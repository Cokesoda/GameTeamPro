using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject firePosition;
    public GameObject wBulletEffect;
    public bool isHit = false;

    ParticleSystem ps;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        ps = wBulletEffect.GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Attack");
                anim.SetFloat("AttackSpeed", 2f);
            }
            //Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo = new RaycastHit();
            if(Physics.Raycast(firePosition.transform.position, Camera.main.transform.forward, out hitInfo, 100))
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    isHit = true;
                    Debug.Log("======================== " + isHit);
                    //EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    //eFSM.HitEnemy(weaponPower);
                }
                else
                {
                    //transform.TransformDirection(Vector3.forward)
                    //Debug.DrawRay(firePosition.transform.position, Camera.main.transform.forward * hitInfo.distance, Color.yellow);
                    wBulletEffect.transform.position = hitInfo.point;
                    wBulletEffect.transform.forward = hitInfo.normal;
                    ps.Play();
                    //ps.Stop();
                    //Destroy(ps, 0.1f);
                }
            }
        }
    }
}
