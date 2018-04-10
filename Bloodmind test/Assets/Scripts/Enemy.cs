using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject waypoint;
    public GameObject researchMaterials;
    public GameObject aimPoint;
    NavMeshAgent agent;

    public float enemyHealth;

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
            int i;
            i = Random.Range(0, 20);
            if(i == 1)
            {
                Instantiate(researchMaterials, gameObject.transform.position, gameObject.transform.rotation);
            }
            Destroy(gameObject);
        }
	}
}