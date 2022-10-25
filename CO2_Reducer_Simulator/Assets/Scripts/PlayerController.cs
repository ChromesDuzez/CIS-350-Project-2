using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float rotateInput = Input.GetAxisRaw("Horizontal") * turnSpeed * Time.deltaTime;
        float moveInput = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * moveInput);
        transform.Rotate(Vector3.up * rotateInput);
    }
}
