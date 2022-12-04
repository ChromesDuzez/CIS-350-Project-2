using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Refrences:")]
    public GameObject bulletPrefab;
    private Rigidbody rb;
    private MeshRenderer mr;
    private MeshRenderer barrelMR;
    private Transform firePoint;
    private bool tankRed = false;

    [Header("Movement:")]
    public float moveSpeed = 10f;
    public float turnSpeed = 10f;

    [Header("Shooting:")]
    public float shootForce = 20f;
    public float timeBetweenShots = 0.5f;
    private float nextShotTime;

    [Header("Stun Effect:")]
    public Material stunnedMaterial;
    public float stunDuration = 3f;
    public float invincibilityDuration = 1f;
    private Material defaultMaterial;
    [HideInInspector] public bool isStunned = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        barrelMR = transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>();
        defaultMaterial = mr.material;
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
            HandleShooting(GlobalSettings.RedTankShoot);
        }
        else if(GlobalSettings.player2Enabled)
        {
            HandleMovement(false);
            HandleShooting(GlobalSettings.BlueTankShoot);
        }
    }

    void HandleMovement(bool player1)
    {
        float rotateInput;
        float moveInput;

        if (player1)
        {
            rotateInput = GlobalSettings.GetAxisRaw("Horizontal") * turnSpeed * Time.deltaTime;
            moveInput = GlobalSettings.GetAxisRaw("Vertical") * moveSpeed; //* Time.deltaTime;
        }
        else
        {
            rotateInput = GlobalSettings.GetAxisRaw("Horizontal2") * turnSpeed * Time.deltaTime;
            moveInput = GlobalSettings.GetAxisRaw("Vertical2") * moveSpeed; //* Time.deltaTime;
        }

        rb.velocity = transform.forward * moveInput;
        transform.Rotate(Vector3.up * rotateInput);
    }

    void HandleShooting(KeyCode inputKey)
    {
        if(!isStunned && Input.GetKeyDown(inputKey))
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

    private void OnTriggerEnter(Collider other)
    {
        if (!isStunned && other.gameObject.tag.Contains("Bullet"))
        {
            StartCoroutine(StunEffect());
        }
    }

    IEnumerator StunEffect()
    {
        isStunned = true;
        float initMoveSpeed = moveSpeed;
        moveSpeed = 0;
        StartCoroutine(StunVisuals());
        yield return new WaitForSeconds(stunDuration);
        moveSpeed = initMoveSpeed;
        yield return new WaitForSeconds(invincibilityDuration);
        isStunned = false;
    }

    IEnumerator StunVisuals()
    {
        while(isStunned)
        {
            mr.material = stunnedMaterial;
            barrelMR.material = stunnedMaterial;
            yield return new WaitForSeconds(0.2f);
            mr.material = defaultMaterial;
            barrelMR.material = defaultMaterial;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public bool AIshoots()
    {
        if (!isStunned)
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
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

        return true;
    }
}
