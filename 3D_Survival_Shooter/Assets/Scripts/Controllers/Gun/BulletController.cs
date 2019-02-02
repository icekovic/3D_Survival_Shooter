using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            //if the first level is loaded
            if(SceneManager.GetActiveScene().name.Equals(Scenes.FirstLevel))
            {
                //check amount of killed zombunnies
                if (hudManager.GetEnemiesKilledCounter() == EnemyManager.GetZombunnyAmount())
                {
                    levelTransition.FirstLevelIsPassed();
                    hudManager.ResetEnemiesKilledCounter();
                    canvasManager.ShowLevelCompletedMenu();
                }
            }

            else if (levelTransition.GetFirstLevelPassed())
            {
                //check amount of killed zombunnies
                if (hudManager.GetEnemiesKilledCounter() == EnemyManager.GetZombearAmount())
                {
                    levelTransition.SecondLevelIsPassed();
                    hudManager.ResetEnemiesKilledCounter();
                    canvasManager.ShowLevelCompletedMenu();
                }
            }

            else if (SceneManager.GetActiveScene().name.Equals(Scenes.ThirdLevel))
            {
                //check amount of killed zombunnies
                if (hudManager.GetEnemiesKilledCounter() == EnemyManager.GetHellephantAmount())
                {
                    //the game is over, no booleans are needed, just show the menu
                    canvasManager.ShowGameCompletedMenu();
                }
            }
        }
    }

    private void DestroyEnemy(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
