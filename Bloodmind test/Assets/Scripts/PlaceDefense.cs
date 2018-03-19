using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDefense : MonoBehaviour
{
    public List<GameObject> placeableDefenses = new List<GameObject>();
    public List<GameObject> placedDefenses = new List<GameObject>();
    public List<GameObject> leveledDefenses = new List<GameObject>();
    GameObject player;
    GameObject visibleDefense;
    public int i;
    bool spawned;

    public float range;

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
        if (Input.GetKeyDown(KeyCode.Alpha4)) { i = 3; }

        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (distance <= range)
        {
            if (!spawned)
            {
                placeableDefenses[i].SetActive(true);

                for (int a = 0; a < placeableDefenses.Count; a++)
                {
                    if (a != i)
                    {
                        placeableDefenses[a].SetActive(false);
                    }
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    placeableDefenses[i].SetActive(false);
                    placedDefenses[i].SetActive(true);
                    player.GetComponent<UpgradeButtons>().turrets.Add(placedDefenses[i].gameObject);
                    spawned = true;
                }
            }

            /*if (Input.GetKeyDown(KeyCode.E) && spawned)
            {
                leveledDefenses[i].SetActive(true);
                placedDefenses[i].SetActive(false);
            }*/
        }
        else if (distance >= range)
        {
            placeableDefenses[i].SetActive(false);
        }
    }
}