using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject firePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if(Physics.Raycast(firePosition.transform.position, Camera.main.transform.forward, out hitInfo, 100))
            {
                //transform.TransformDirection(Vector3.forward)
                Debug.DrawRay(firePosition.transform.position, Camera.main.transform.forward * hitInfo.distance, Color.yellow);
            }

        }
    }
}
