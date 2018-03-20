using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    public float baseHealth;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if(baseHealth <= 0)
        {
            Debug.Log("Game Over");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            baseHealth--;
            other.gameObject.GetComponent<Enemy>().enemyHealth = 0;
        }
    }
}