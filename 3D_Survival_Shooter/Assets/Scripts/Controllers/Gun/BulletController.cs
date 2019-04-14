using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    public float speed;
    private HudManager hudManager;

    private void Awake()
    {
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
            DestroyEnemy(other);
        }
    }

    private void DestroyEnemy(Collider other)
    {
        hudManager.IncrementEnemiesKilledCounter();
        hudManager.IncreaseScoreCounter();      
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
