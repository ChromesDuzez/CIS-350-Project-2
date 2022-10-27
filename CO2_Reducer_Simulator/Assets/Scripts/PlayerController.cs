using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float moveSpeed = 10f;
    public float turnSpeed = 10f;
    public float shootForce = 10f;
    public float timeBetweenShots = 0.5f;
    private float nextShotTime;


    private bool tankRed = false;
    private Rigidbody rb;
    private Transform firePoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        firePoint = transform.GetChild(1);

        if(gameObject.tag == "TankRed")
        {
            tankRed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tankRed)
        {
            HandleMovement(true);
            HandleShooting(KeyCode.E);
        }
        else
        {
            HandleMovement(false);
            HandleShooting(KeyCode.Slash);
        }
    }

    void HandleMovement(bool player1)
    {
        float rotateInput;
        float moveInput;

        if (player1)
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

    void HandleShooting(KeyCode inputKey)
    {
        if(Input.GetKeyDown(inputKey))
        {
            // Limits the rate at which projectiles can be fired
            bool canShoot = Time.time > nextShotTime;

            if (canShoot)
            {
                GameObject spawnedBullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
                spawnedBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Impulse);
                Destroy(spawnedBullet, 5f);

                // Resets projectile delay timer
                nextShotTime = Time.time + timeBetweenShots;
            }
        }
    }
}
