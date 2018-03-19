using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarBullet : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject target;
    public float speed;
    public float height;
    public float yAxis;
    public float oldYAxis;
    float travel;
    public GameObject miniBullet;
    public GameObject shotBullet;

    int i;

    void Start ()
    {
        rb.AddForce(0, height, 0);
    }

    void FixedUpdate ()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            yAxis = gameObject.transform.position.y;
            travel = yAxis - oldYAxis;
            oldYAxis = yAxis;
        }
    }
    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
        }
        if (travel <= 0 && i <= 4)
        {
            shotBullet = Instantiate(miniBullet, gameObject.transform.position, gameObject.transform.rotation);
            shotBullet.GetComponent<MiniMortarBullet>().target = target;
            i++;
        }
        if (i == 4)
        {
            Destroy(gameObject);
        }


    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().enemyHealth--;
            Destroy(gameObject);
        }
         else if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}