using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    public float speed;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        gameObject.transform.Translate(0, 0, -speed);
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
	}
}