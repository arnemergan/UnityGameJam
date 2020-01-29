using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float directionX = 0f;
    private float directionY = 0f;
    private float tempX = 0f;
    private float tempY = 0f;
    public float movementSpeed;
    public float deadZone;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
    }
    void movement(){
        //Rotation
        tempX = Input.GetAxis("Mouse X");
        tempY = Input.GetAxis("Mouse Y");

        //Only assign joystick axes if they're outside of deadzone
        if(!(Math.Abs(tempY) < deadZone && Math.Abs(tempX) < deadZone)){
            directionX = tempX;
            directionY = tempY;
        }

        //Only assign rotation if at least one of the directions is nonzero, causes an error otherwise
        if(directionX != 0 || directionY != 0){
            Quaternion rotation = Quaternion.LookRotation(new Vector3(directionX, 0, directionY))*Quaternion.Euler(0,90,0);
            transform.rotation = rotation;
        }
        
        //Movement
        rb.velocity = new Vector3(Input.GetAxis("Horizontal")*movementSpeed, rb.velocity.y, Input.GetAxis("Vertical")*movementSpeed);
    }

  
}
