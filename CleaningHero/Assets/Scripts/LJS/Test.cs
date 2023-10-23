using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float xMouse;
    float yMouse;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xMouse = Input.GetAxisRaw("Mouse X");
        yMouse = Input.GetAxisRaw("Mouse Y");
        Vector3 rotateMouse = new Vector3(yMouse, 0, xMouse);
        transform.rotation = Quaternion.Euler(rotateMouse);
        transform.position = target.position;
    }
}
