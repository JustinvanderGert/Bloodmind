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
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    upgradeScreen.SetActive(false);
                    player.GetComponent<CharacterMOV>().menu = false;
                }
            }
        }
    }

    public void DamageUpgradeButton()
    {
        if (player.GetComponent<Player>().totalGold >= turret.GetComponent<Turret>().damageUpgradeCost)
        {
            player.GetComponent<Player>().totalGold -= turret.GetComponent<Turret>().damageUpgradeCost;
            turret.GetComponent<Turret>().damageUpgrade[0].SetActive(true);
            player.GetComponent<CharacterMOV>().menu = false;
            upgradeScreen.SetActive(false);

            turret.SetActive(false);
            player.GetComponent<UpgradeButtons>().turrets.Add(turret.GetComponent<Turret>().damageUpgrade[0].gameObject);
            player.GetComponent<UpgradeButtons>().turrets.Remove(turret.gameObject);
        }
    }
    public void SpeedUpgradeButton()
    {
        if(player.GetComponent<Player>().totalGold >= turret.GetComponent<Turret>().speedUpgradeCost)
        {
            player.GetComponent<Player>().totalGold -= turret.GetComponent<Turret>().speedUpgradeCost;
            turret.GetComponent<Turret>().speedUpgrade[0].SetActive(true);
            player.GetComponent<CharacterMOV>().menu = false;
            upgradeScreen.SetActive(false);

            player.GetComponent<UpgradeButtons>().turrets.Add(turret.GetComponent<Turret>().speedUpgrade[0].gameObject);
            player.GetComponent<UpgradeButtons>().turrets.Remove(turret.gameObject);

            turret.gameObject.SetActive(false);
        }
    }
}