using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    public float speed;
    private string activeScene;

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
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
