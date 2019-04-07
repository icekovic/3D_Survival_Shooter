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

    public GunController gun;
    private LevelTransition levelTransition;
    private ScenesManager scenesManager;
    private SoundManager soundManager;

    [SerializeField]
    private Slider healthBar;

    [SerializeField]
    private int startingHealth;

    [SerializeField]
    private int currentHealth;

    [SerializeField]
    private int healthReduceAmount;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");

        levelTransition = FindObjectOfType<LevelTransition>();
        scenesManager = FindObjectOfType<ScenesManager>();
        soundManager = FindObjectOfType<SoundManager>();

        currentHealth = startingHealth;
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

    private void OnTriggerEnter(Collider other)
    {
        //if(other.tag.Equals(Tags.BlueJewel))
        //{            
        //    levelTransition.FirstLevelIsPassed();
        //    PlayerCollectedBlueJewel(other);
        //}

        //else if(other.tag.Equals(Tags.PinkJewel))
        //{
        //    levelTransition.SecondLevelIsPassed();
        //    PlayerCollectedPinkJewel(other);
        //}

        //else if (other.tag.Equals(Tags.YellowJewel))
        //{
        //    PlayerCollectedYellowJewel(other);
        //}

        if(other.tag.Equals(Tags.Enemy))
        {
            TakeDamage();
        }
    }

    private void PlayerCollectedYellowJewel(Collider other)
    {
        soundManager.StopBackgroundMusic();
        soundManager.PlayGameCompletedSound();
        scenesManager.CloseHud();
        scenesManager.ShowGameCompletedMenu();
        Destroy(other);
    }

    private void PlayerCollectedPinkJewel(Collider other)
    {
        soundManager.StopBackgroundMusic();
        soundManager.PlayLevelCompletedSound();
        scenesManager.CloseHud();
        scenesManager.ShowLevelCompletedMenu();
        Destroy(other.gameObject);
    }

    private void PlayerCollectedBlueJewel(Collider other)
    {
        soundManager.StopBackgroundMusic();
        soundManager.PlayLevelCompletedSound();
        scenesManager.CloseHud();
        scenesManager.ShowLevelCompletedMenu();
        Destroy(other.gameObject);
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

    public void TakeDamage()
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= healthReduceAmount;

        // Set the health bar's value to the current health.
        healthBar.value = currentHealth;

        // Play the hurt sound effect.
        //playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Die();
        }
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
    }
}
