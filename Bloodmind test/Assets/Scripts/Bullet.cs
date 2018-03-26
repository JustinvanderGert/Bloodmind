using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;

    void Start()
    {
        StartCoroutine(DestroyBullet());
    }

    void FixedUpdate()
    {
        gameObject.transform.Translate(0, 0, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().enemyHealth -= damage;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Heavy_Enemy")
        {
            other.gameObject.GetComponent<Enemy>().enemyHealth -= damage;
            Destroy(gameObject);
        }
    }

    public IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}