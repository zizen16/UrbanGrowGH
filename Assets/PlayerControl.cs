using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float jumpHeight;
    public float grav = -9.81f;

    [Header("Mouse")]
    public float mouseSense;
    public float xRot;

    [Header("Camera")]
    public Transform cameraRig;

    CharacterController control;
    Vector3 velocity;
    bool isGround;

    void Start()
    {
        control = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //to stay grounded
        isGround = control.isGrounded;
        if (isGround && velocity.y < 0) { velocity.y = -2f; }

        //movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moves = transform.right * x + transform.forward * z;
        control.Move(moves * speed * Time.deltaTime);

        //jump
        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * grav);
        }

        //gravity
        velocity.y += grav * Time.deltaTime;
        control.Move(velocity * Time.deltaTime);

        //mouse camera control
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        if (cameraRig != null)
        {
            cameraRig.localRotation = Quaternion.Euler(xRot, 0, 0);
        }
        transform.Rotate(Vector3.up * mouseX);

    }

    
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Apartment")
        {
            if (Input.GetKey(KeyCode.E))
            {
                UIManager2.instance.playerEnteredApartment = true;

            }
        }
        else if (other.gameObject.tag == "GPatch")
        {
            print("daadadad");
            if (Input.GetKey(KeyCode.E))
            {
                UIManager2.instance.playerEnteredGarden = true;
            }
        }
    }
}
