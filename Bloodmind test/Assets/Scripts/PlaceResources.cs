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

    }
}