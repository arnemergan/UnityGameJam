using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        moveVelocity = moveInput * moveSpeed;
        if(Input.GetAxis("Mouse X") != 0 && Input.GetAxis("Mouse Y") != 0){
            Vector3 lookDirection = new Vector3(Input.GetAxis("Mouse X") / 25, 0, Input.GetAxis("Mouse Y") / 25);
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
        rb.velocity = moveVelocity;
    }
}
