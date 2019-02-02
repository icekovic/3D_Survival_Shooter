using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    private HUDManager hudManager;

    private void Start()
    {
        hudManager = FindObjectOfType<HUDManager>();
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
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
