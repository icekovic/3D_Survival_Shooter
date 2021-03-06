﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;
    public int damage;
    public BulletController bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotsCounter;
    public Transform firePoint;

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (isFiring)
        {
            shotsCounter -= Time.deltaTime;
            if (shotsCounter <= 0)
            {
                shotsCounter = timeBetweenShots;
                soundManager.PlayGunshotSound();
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
            }
        }

        else
        {
            shotsCounter = 0;
        }
    }
}
