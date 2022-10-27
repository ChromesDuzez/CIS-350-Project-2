using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 10f;

    private bool tankRed = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if(gameObject.tag == "TankRed")
        {
            tankRed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float rotateInput;
        float moveInput;

        if (tankRed)
        {
            rotateInput = Input.GetAxisRaw("Horizontal") * turnSpeed * Time.deltaTime;
            moveInput = Input.GetAxisRaw("Vertical") * moveSpeed; //* Time.deltaTime;
        }
        else
        {
            rotateInput = Input.GetAxisRaw("Horizontal2") * turnSpeed * Time.deltaTime;
            moveInput = Input.GetAxisRaw("Vertical2") * moveSpeed; //* Time.deltaTime;
        }

        rb.velocity = transform.forward * moveInput;
        transform.Rotate(Vector3.up * rotateInput);
    }
}
