using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMortarBullet : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject target;
    public float speed;
    public float height;

    void Start ()
    {
        
    }
    
    void Update ()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
	}

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().enemyHealth--;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}