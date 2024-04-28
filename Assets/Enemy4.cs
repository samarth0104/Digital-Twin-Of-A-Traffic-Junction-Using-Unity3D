using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy4 : MonoBehaviour
{
    private Transform player4Transform;
    private NavMeshAgent nav4;

    // Start is called before the first frame update
    void Start()
    {
        player4Transform = GameObject.FindGameObjectWithTag("Player4").transform;
        nav4 = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav4.destination = player4Transform.position;
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player4"))
        {
            // Destroy the enemy object
            Destroy(gameObject);
        }
    }
}

