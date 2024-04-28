using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform player1Transform;
    private NavMeshAgent nav1;

    // Start is called before the first frame update
    void Start()
    {
        player1Transform = GameObject.FindGameObjectWithTag("Player1").transform;
        nav1 = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav1.destination = player1Transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player1"))
        {
            // Destroy the enemy object
            Destroy(gameObject);
        }
    }
}




