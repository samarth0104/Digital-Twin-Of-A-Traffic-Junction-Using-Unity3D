using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{
    private Transform player2Transform;
    private NavMeshAgent nav2;

    // Start is called before the first frame update
    void Start()
    {
        player2Transform = GameObject.FindGameObjectWithTag("Player2").transform;
        nav2 = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav2.destination = player2Transform.position;
    }
}




