using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    bool spawned;

	void Start ()
    {
        spawned = false;
	}
	
	void Update () 
    {
        if (!spawned)
        {
            StartCoroutine(Spawner());
            spawned = true;
        }
	}

    public IEnumerator Spawner()
    {
        yield return new WaitForSeconds(5);
        Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation);
        spawned = false;
    }
}