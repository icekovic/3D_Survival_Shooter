using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IPlayerMovement, IPlayerHealth
{
    public float speed = 6f;
    private Vector3 movement;
    private Animator animator;
    private Rigidbody rigidBody;
    float camRayLength = 100f;
    int floorMask;

    private bool isWalking = false;
    bool isDead = false;
    bool damaged = false;

    //public int startingHealth;
    //public int currentHealth;
    //public Slider healthSlider;

    //shooting
    //public int damagePerShot = 20;
    //public float timeBetweenBullets = 0.15f;
    //public float range = 100f;

    public GunController gun;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        //startingHealth = 100;
        //currentHealth = startingHealth;
        floorMask = LayerMask.GetMask("Floor");
    }

    void Start()
    {
        
    }

    void Update()
    {
        Shoot();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
        Turn();
        Animate(horizontal, vertical);
    }

    public void Move(float horizontal, float vertical)
    {
        movement.Set(horizontal, 0f, vertical);
        movement = movement.normalized * speed * Time.deltaTime;
        rigidBody.MovePosition(transform.position + movement);
    }

    public void Turn()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            rigidBody.MoveRotation(newRotatation);
        }
    }

    public void Animate(float horizontal, float vertical)
    {
        if (horizontal != 0f || vertical != 0f)
        {
            isWalking = true;
        }

        animator.SetBool("IsWalking", isWalking);
    }

    public void TakeDamage(int amount)
    {
        damaged = true;

        // Reduce the current health by the damage amount.
        //currentHealth -= amount;

        // Set the health bar's value to the current health.
        //healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        //playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        //if (currentHealth <= 0 && !isDead)
        //{
            // ... it should die.
        //    Die();
        //}
    }

    public void Die()
    {
        isDead = true;

        // Turn off any remaining shooting effects.
        //playerShooting.DisableEffects();

        // Tell the animator that the player is dead.
        animator.SetTrigger("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        // Turn off the movement and shooting scripts.
        //playerMovement.enabled = false;
        //playerShooting.enabled = false;

        Debug.Log("Died");
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gun.isFiring = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            gun.isFiring = false;
        }
    }
}
