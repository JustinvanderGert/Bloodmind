using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemy = new List<GameObject>();
    public GameObject victoryScreen;
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

        if (i < enemy.Count)
        {
            Instantiate(enemy[i], gameObject.transform.position, gameObject.transform.rotation);
            i++;
            spawning = false;
        }
        else if (i >= enemy.Count)
        {
            victoryScreen.SetActive(true);
            spawning = false;
        }
    }
}