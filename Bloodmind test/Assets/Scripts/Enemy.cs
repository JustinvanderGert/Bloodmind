using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject waypoint;
    NavMeshAgent agent;

    public int enemyHealth;
    //public float speed;

	void Start ()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        waypoint = GameObject.FindGameObjectWithTag("Waypoint");
	}
	
	void Update ()
    {
        agent.SetDestination(waypoint.transform.position);

        //gameObject.transform.Translate(0, 0, -speed);
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
	}
}