using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    public float speed;

    private HudManager hudManager;
    private string activeScene;

    private void Awake()
    {
        activeScene = SceneManager.GetActiveScene().name;
        hudManager = FindObjectOfType<HudManager>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals(Tags.Enemy))
        {
            hudManager.IncreaseScoreCounter();
            hudManager.IncrementEnemiesKilledCounter();
            DestroyEnemy(other);
        }
    }

    private void DestroyEnemy(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
