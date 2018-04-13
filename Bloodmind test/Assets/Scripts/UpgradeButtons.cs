using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtons : MonoBehaviour
{
    public List<GameObject> turrets = new List<GameObject>();

    public GameObject upgradeScreen;
    public GameObject fireArrowButton;
    public GameObject doubleShotButton;
    public GameObject turret;
    public float range;
    public int i = 0;

    GameObject player;

    public bool fireArrowUnlocked;
    public bool doubleShotUnlocked;

    void Start ()
    {
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
                    player.GetComponent<CharacterMOV>().menu = true;
                    upgradeScreen.SetActive(true);

                    if (fireArrowUnlocked)
                    {
                        fireArrowButton.SetActive(true);
                    }
                    if (doubleShotUnlocked)
                    {
                        doubleShotButton.SetActive(true);
                    }
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
        if (player.GetComponent<Player>().totalGold >= turret.GetComponent<Price>().damageUpgradeCost && fireArrowUnlocked)
        {
            player.GetComponent<Player>().totalGold -= turret.GetComponent<Price>().damageUpgradeCost;
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
        if(player.GetComponent<Player>().totalGold >= turret.GetComponent<Price>().speedUpgradeCost && doubleShotUnlocked)
        {
            player.GetComponent<Player>().totalGold -= turret.GetComponent<Price>().speedUpgradeCost;
            turret.GetComponent<Turret>().speedUpgrade[0].SetActive(true);
            player.GetComponent<CharacterMOV>().menu = false;
            upgradeScreen.SetActive(false);

            player.GetComponent<UpgradeButtons>().turrets.Add(turret.GetComponent<Turret>().speedUpgrade[0].gameObject);
            player.GetComponent<UpgradeButtons>().turrets.Remove(turret.gameObject);

            turret.gameObject.SetActive(false);
        }
    }
    public void ExitButton()
    {
        player.GetComponent<CharacterMOV>().menu = false;
        upgradeScreen.SetActive(false);
    }
}