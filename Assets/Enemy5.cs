using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy5 : MonoBehaviour
{
    private Transform player5Transform;
    private NavMeshAgent nav5;

    // Start is called before the first frame update
    void Start()
    {
        player5Transform = GameObject.FindGameObjectWithTag("Player5").transform;
        nav5 = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav5.destination = player5Transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player5"))
        {
            // Destroy the enemy object
            Destroy(gameObject);
        }
    }
}
