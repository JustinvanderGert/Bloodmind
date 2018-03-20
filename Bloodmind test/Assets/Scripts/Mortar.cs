using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar : MonoBehaviour
{
    public List<GameObject> target = new List<GameObject>();
    public Transform bulletPoint;
    public GameObject bullet;
    public GameObject shotBullet;

    public float speed;
    public float cost;
    public Coroutine a;
    public GameObject currentTarget;
    bool shot;

    void Start()
    {
        shot = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            target.Add(other.gameObject);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            target.Remove(other.gameObject);
        }
    }

    void Update()
    {
        for(int a = 0; a < target.Count; a++)
        {
            if(target[a].GetComponent<Enemy>().enemyHealth <= 0)
            {
                target.Remove(target[a]);
            }
            if(target[a] == null)
            {
                target.Remove(target[a]);
            }
        }

        if (target.Count > 0)
        {
            currentTarget = target[0];
            Vector3 targetDir = currentTarget.transform.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, speed * Time.deltaTime, 0.0F);
            newDir.y = 0;
            transform.rotation = Quaternion.LookRotation(newDir);
        }

        if (!shot & target.Count > 0)
        {
            a = StartCoroutine(Shoot());
            shot = true;
        }
        if (currentTarget != null && currentTarget.gameObject.GetComponent<Enemy>().enemyHealth <= 0)
        {
            target.Remove(currentTarget.gameObject);
        }
        if (target.Count <= 0)
        {
            StopCoroutine(a);
            shotBullet = null;
            shot = false;
            target.Remove(currentTarget.gameObject);
        }
    }

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2);

        shotBullet = Instantiate(bullet, bulletPoint.transform.position, bulletPoint.transform.rotation);
        shotBullet.GetComponent<MortarBullet>().target = currentTarget;
        shot = false;
    }
}