using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject firePosition;
    public GameObject wBulletEffect;

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
        if (Input.GetMouseButtonDown(0))
        {
            if (anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Attack");
            }
            //Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo = new RaycastHit();
            if(Physics.Raycast(firePosition.transform.position, Camera.main.transform.forward, out hitInfo, 100))
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
