using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    private void Awake()
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
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
