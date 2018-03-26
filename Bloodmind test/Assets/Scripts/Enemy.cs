using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject waypoint;
    NavMeshAgent agent;

    public int enemyHealth;

	void Start ()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        waypoint = GameObject.FindGameObjectWithTag("Waypoint");
	}
	
	void Update ()
    {
        agent.SetDestination(waypoint.transform.position);
        
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
	}
}