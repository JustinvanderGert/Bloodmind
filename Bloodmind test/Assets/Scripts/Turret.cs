using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<GameObject> damageUpgrade = new List<GameObject>();
    public List<GameObject> speedUpgrade = new List<GameObject>();
    public List<GameObject> target = new List<GameObject>();

    public Transform bulletPoint;
    public Transform bulletPoint2;
    public GameObject bullet;
    public GameObject rotatingPart;
    public GameObject aimingPart;
    
    public float reloadTime;
    public float range;
    public float speed;
    
    GameObject currentTarget;
    Coroutine a;
    bool shot;
    bool coroutineIsRunning = false;

    void Start ()
    {
        shot = false;
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            target.Add(other.gameObject);
        }
        if (other.gameObject.tag == "Heavy_Enemy")
        {
            target.Add(other.gameObject);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            target.Remove(other.gameObject);
        }
        if (other.gameObject.tag == "Heavy_Enemy")
        {
            target.Remove(other.gameObject);
        }
    }

    void Update()
    {
        for (int a = 0; a < target.Count; a++)
        {
            if (target[a] == null)
            {
                target.Remove(target[a]);
            }
            if (target[a].GetComponent<Enemy>().enemyHealth <= 0)
            {
                target.Remove(target[a]);
            }
        }

        if (target.Count > 0)
        {
            currentTarget = target[0];

            Vector3 targetPostition = new Vector3(currentTarget.transform.position.x, rotatingPart.transform.position.y, currentTarget.transform.position.z);
            rotatingPart.transform.LookAt(targetPostition);

            aimingPart.transform.LookAt(currentTarget.transform);
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
        if (target.Count <= 0 && coroutineIsRunning)
        {
            StopCoroutine(a);
            shot = false;
            target.Remove(currentTarget.gameObject);
        }
    }

    public IEnumerator Shoot()
    {
        coroutineIsRunning = true;
        yield return new WaitForSeconds(reloadTime);

        Instantiate(bullet, bulletPoint.transform.position, bulletPoint.transform.rotation);
        if (bulletPoint2 != null)
        {
            Instantiate(bullet, bulletPoint2.transform.position, bulletPoint.transform.rotation);
        }
        shot = false;
        coroutineIsRunning = false;
    }
}