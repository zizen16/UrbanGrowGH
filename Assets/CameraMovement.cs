using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float speedRot;

    public float speedMult = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedRot = Input.GetAxis("Horizontal") * -speedMult;
       
    }

    private void FixedUpdate()
    {
        RotateCamera();
    }

    public void RotateCamera() { 
        this.transform.Rotate(0,speedRot,0);
    }
}
