using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //private Transform player;
    private GameObject player;
    private NavMeshAgent navMesh;

    private void Awake()
    {
        //player = GameObject.Find("Player").transform;
        player = GameObject.Find("Player");
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        //navMesh.SetDestination(player.position);

        if(player != null)
        {
            navMesh.SetDestination(player.transform.position);
        }
    }
}
