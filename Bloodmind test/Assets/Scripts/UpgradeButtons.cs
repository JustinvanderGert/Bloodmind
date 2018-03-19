using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtons : MonoBehaviour
{
    public List<GameObject> turrets = new List<GameObject>();
    public GameObject turret;
    public float range;

    public GameObject upgradeScreen;
    GameObject player;

    public int i = 0;
    int damI = 0;
    int speedI = 0;

    void Start ()
    {
        upgradeScreen = GameObject.FindGameObjectWithTag("TurretUpgradeScreen");
        player = GameObject.FindGameObjectWithTag("Player");
        upgradeScreen.SetActive(false);
    }
	
	void Update ()
    {
        for (i = 0; i < turrets.Count; i++)
        {
            float distance = Vector3.Distance(player.transform.position, turrets[i].transform.position);

            if (distance <= range)
            {
                turret = turrets[i].gameObject;

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    upgradeScreen.SetActive(true);
                    player.GetComponent<CharacterMOV>().menu = true;
                }
            }
        }
    }

    public void DamageUpgradeButton()
    {
        turret.GetComponent<Turret>().damageUpgrade[damI].SetActive(true);
        player.GetComponent<CharacterMOV>().menu = false;
        upgradeScreen.SetActive(false);
        Debug.Log("Laat player weer lopen.");

        turret.SetActive(false);
        Debug.Log("Zet lvl1 uit");
    }
    public void SpeedUpgradeButton()
    {
        turret.GetComponent<Turret>().speedUpgrade[speedI].SetActive(true);
        player.GetComponent<CharacterMOV>().menu = false;
        upgradeScreen.SetActive(false);

        turret.gameObject.SetActive(false);
    }
}