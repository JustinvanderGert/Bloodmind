using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDefense : MonoBehaviour
{
    public List<GameObject> placeableDefenses = new List<GameObject>();
    public List<GameObject> placedDefenses = new List<GameObject>();
    public List<GameObject> leveledDefenses = new List<GameObject>();
    GameObject visibleDefense;
    GameObject player;
    bool spawned;

    public GameObject turret;
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
        if (Input.GetKeyDown(KeyCode.Alpha4)) { i = 3; }

        float distancePlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (distancePlayer <= range)
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
                if (Input.GetKeyDown(KeyCode.E) && i != 0 && turret.GetComponent<Turret>().cost <= player.GetComponent<Player>().totalGold)
                {
                    placeableDefenses[i].SetActive(false);
                    placedDefenses[i].SetActive(true);
                    player.GetComponent<UpgradeButtons>().turrets.Add(placedDefenses[i].gameObject);
                    player.GetComponent<Player>().totalGold -= turret.GetComponent<Turret>().cost;
                    spawned = true;
                }
            }
        }
        else if (distancePlayer >= range)
        {
            placeableDefenses[i].SetActive(false);
        }
    }
}