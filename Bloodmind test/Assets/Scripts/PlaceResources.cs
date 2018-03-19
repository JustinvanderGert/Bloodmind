using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceResources : MonoBehaviour
{
    public List<GameObject> placeableResources = new List<GameObject>();
    public List<GameObject> placedResources = new List<GameObject>();
    public List<GameObject> leveledResources = new List<GameObject>();
    GameObject visibleResource;
    GameObject player;
    bool spawned;

    public float range;
    public int i;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawned = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { i = 0; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { i = 1; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { i = 2; }

        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (distance <= range)
        {
            if (!spawned)
            {/*
                placeableResources[i].SetActive(true);
                if (i == 0)
                {
                    placeableResources[1].SetActive(false);
                }
                else if (i == 1)
                {
                    placeableResources[0].SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    placeableResources[i].SetActive(false);
                    placedResources[i].SetActive(true);
                    spawned = true;
                }*/

                placeableResources[i].SetActive(true);

                for (int a = 0; a < placeableResources.Count; a++)
                {
                    if (a != i)
                    {
                        placeableResources[a].SetActive(false);
                    }
                }
                if (Input.GetKeyDown(KeyCode.E) && i != 0)
                {
                    placeableResources[i].SetActive(false);
                    placedResources[i].SetActive(true);
                    spawned = true;
                }
            }
        }
        else if (distance >= range)
        {
            placeableResources[i].SetActive(false);
        }
    }
}