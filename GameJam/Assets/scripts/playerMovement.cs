﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float directionX = 0f;
    private float directionY = 0f;
    private float tempX = 0f;
    private float tempY = 0f;
    public float movementSpeed;
    public float deadZone;
    private Actions actions;

    public int playerNumber;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        actions = GetComponent<Actions>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Math.Abs(rb.velocity.x) <= 0.01 && Math.Abs(rb.velocity.z) <= 0.01 && Math.Abs(rb.velocity.y) <= 0.01){
            actions.Stay();
        }else if(
            Math.Abs(rb.velocity.z) > 0.01 && Math.Abs(rb.velocity.z) <= 0.5 ||
            Math.Abs(rb.velocity.x) > 0.01 && Math.Abs(rb.velocity.x) <= 0.5){
            actions.Walk();
        }else if(Math.Abs(rb.velocity.z) > 0.5 || Math.Abs(rb.velocity.y) > 0.5 || Math.Abs(rb.velocity.x) > 0.5 ){
            actions.Run();
        }
        movement();
    }
    void movement(){
        //Rotation
        tempX = Input.GetAxis("J" + playerNumber + "MouseX");
        tempY = Input.GetAxis("J" + playerNumber + "MouseY");

        //Only assign joystick axes if they're outside of deadzone
        if(!(Math.Abs(tempY) < deadZone && Math.Abs(tempX) < deadZone)){
            directionX = tempX;
            directionY = tempY;
        }

        //Only assign rotation if at least one of the directions is nonzero, causes an error otherwise
        if(directionX != 0 || directionY != 0){
            Quaternion rotation = Quaternion.LookRotation(new Vector3(directionX, 0, directionY))*Quaternion.Euler(0,180,0);
            transform.rotation = rotation;
        }
        rb.velocity = new Vector3(Input.GetAxis("J" + playerNumber + "Horizontal")*movementSpeed, rb.velocity.y, Input.GetAxis("J" + playerNumber + "Vertical")*movementSpeed);
    }

  
}
