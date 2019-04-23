using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraForward : MonoBehaviour
{
    public Camera myCamera;
    public float sensitivity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myCamera.transform.Translate(Vector3.forward * sensitivity);
        if(myCamera.transform.position.z > 50.0f)
        {
            myCamera.transform.position = new Vector3(-7, 0, -14);
        }
    }
}
