using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3 : MonoBehaviour
{
    private Transform player3Transform;
    private NavMeshAgent nav3;

    // Start is called before the first frame update
    void Start()
    {
        player3Transform = GameObject.FindGameObjectWithTag("Player3").transform;
        nav3 = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav3.destination = player3Transform.position;
    }
}




