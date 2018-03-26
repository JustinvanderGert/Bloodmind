using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemy = new List<GameObject>();
    bool spawning;
    int i;

	void Start ()
    {
        spawning = false;
	}
	
	void Update () 
    {
        if (!spawning)
        {
            StartCoroutine(Spawner());
            spawning = true;
        }
	}

    public IEnumerator Spawner()
    {
        yield return new WaitForSeconds(5);
        Instantiate(enemy[i], gameObject.transform.position, gameObject.transform.rotation);
        ResetSpawner();
    }

    public void ResetSpawner()
    {
        if (i != enemy.Count)
        {
            i++;
            spawning = false;
        }else if(i == enemy.Count) { i = 0; spawning = false; }
    }
}