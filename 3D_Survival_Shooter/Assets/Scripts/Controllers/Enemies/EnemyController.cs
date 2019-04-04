using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navMesh;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        navMesh.SetDestination(player.position);
    }
}
