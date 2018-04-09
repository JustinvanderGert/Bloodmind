using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public GameObject particleSystem;
    public float timeToHurt;
    Collider kilBox;

	void Start ()
    {
        kilBox = gameObject.GetComponent<Collider>();
        particleSystem.SetActive(false);
        kilBox.enabled = false;
    }
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            kilBox.enabled = true;
            particleSystem.SetActive(true);
        }else { particleSystem.SetActive(false); kilBox.enabled = false; }
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().enemyHealth -= timeToHurt;
        }
        if (other.gameObject.tag == "Heavy_Enemy")
        {
            other.gameObject.GetComponent<Enemy>().enemyHealth -= timeToHurt;
        }
    }
}