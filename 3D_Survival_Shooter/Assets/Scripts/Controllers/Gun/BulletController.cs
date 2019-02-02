using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    private HUDManager hudManager;
    private CanvasManager canvasManager;
    private LevelTransition levelTransition;

    private void Start()
    {
        hudManager = FindObjectOfType<HUDManager>();
        canvasManager = FindObjectOfType<CanvasManager>();
        levelTransition = FindObjectOfType<LevelTransition>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals(Tags.Enemy))
        {
            hudManager.IncrementEnemiesKilledCounter();
            hudManager.IncreaseScoreCounter();
            DestroyEnemy(other);
            
            if(hudManager.GetEnemiesKilledCounter() == EnemyManager.GetZombunnyAmount())
            {
                levelTransition.FirstLevelIsPassed();
                canvasManager.ShowLevelCompletedMenu();
            }
        }
    }

    private void DestroyEnemy(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
