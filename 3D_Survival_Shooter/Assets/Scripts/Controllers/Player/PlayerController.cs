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

    public GunController gun;
    private LevelTransition levelTransition;
    private ScenesManager scenesManager;
    private SoundManager soundManager;
    private HudManager hudManager;

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
        hudManager = FindObjectOfType<HudManager>();

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
        if(other.tag.Equals(Tags.Enemy))
        {
            TakeDamage();
        }

        if(other.tag.Equals(Tags.GreenJewel))
        {
            levelTransition.FirstLevelIsPassed();
            PlayerCollectedGreenJewel(other);
        }

        if(other.tag.Equals(Tags.PinkJewel))
        {
            levelTransition.SecondLevelIsPassed();
            PlayerCollectedPinkJewel(other);
        }

        if(other.tag.Equals(Tags.YellowJewel))
        {
            levelTransition.ThirdLevelIsPassed();
            PlayerCollectedYellowJewel(other);
        }
    }

    private void PlayerCollectedGreenJewel(Collider other)
    {
        soundManager.StopBackgroundMusic();
        soundManager.PlayLevelCompletedSound();
        scenesManager.CloseHud();
        scenesManager.ShowLevelCompletedMenu();
        Destroy(other.gameObject);
    }

    private void PlayerCollectedPinkJewel(Collider other)
    {
        soundManager.StopBackgroundMusic();
        soundManager.PlayLevelCompletedSound();
        scenesManager.CloseHud();
        scenesManager.ShowLevelCompletedMenu();
        Destroy(other.gameObject);
    }

    private void PlayerCollectedYellowJewel(Collider other)
    {
        soundManager.StopBackgroundMusic();
        soundManager.PlayGameCompletedSound();
        scenesManager.CloseHud();
        scenesManager.ShowGameCompletedMenu();
        Destroy(other);
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
        currentHealth -= healthReduceAmount;
        healthBar.value = currentHealth;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        hudManager.TakeOneLife();

        if(hudManager.GetLivesCounter() > 0)
        {
            soundManager.StopBackgroundMusic();
            soundManager.PlayPlayerDiedSound();
            scenesManager.ShowPlayerDiedMenu();
            scenesManager.CloseHud();
            Destroy(this.gameObject);   //player is destroyed
        }
        
        else
        {
            scenesManager.ShowGameOverMenu();
            scenesManager.CloseHud();
            Destroy(this.gameObject);   //player is destroyed
        }
    }
}
