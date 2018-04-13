using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResearchStation : MonoBehaviour
{
    public GameObject ballistaUpgradesMap;
    public GameObject trebuchetUpgradesMap;
    public GameObject goldMineUpgradesMap;
    public GameObject wallUpgradesMap;

    public GameObject researchScreen;
    public Text knowledgeText;

    GameObject player;
    GameObject flameThrower;

    public int knowledge;
    public int fireArrowCost;
    public int doubleShotCost;

    bool inResearchScreen = false;
    bool dontKeepTrue = false;

    bool ballistaMenu = false;
    bool trebuchetMenu = false;
    bool goldMineMenu = false;
    bool wallMenu = false;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        flameThrower = GameObject.FindGameObjectWithTag("Flamethrower");
    }
	
	void Update ()
    {
        knowledgeText.text = "Knowledge: " + knowledge;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inResearchScreen = false;
        }

        if (inResearchScreen)
        {
            researchScreen.SetActive(true);
            player.GetComponent<CharacterMOV>().menu = true;
            flameThrower.GetComponent<Flamethrower>().allowed = false;
            dontKeepTrue = false;
        }
        else if (!dontKeepTrue)
        {
            researchScreen.SetActive(false);
            player.GetComponent<CharacterMOV>().menu = false;
            flameThrower.GetComponent<Flamethrower>().allowed = true;
        }

        if(player.GetComponent<CharacterMOV>().menu == false)
        {
            dontKeepTrue = true;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.tag == "Player")
        {
            inResearchScreen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inResearchScreen = false;
        }
    }

    public void BallistaUpgrades()
    {
        ballistaMenu = !ballistaMenu;
        ballistaUpgradesMap.SetActive(ballistaMenu);

        if (trebuchetMenu | goldMineMenu | wallMenu)
        {
            trebuchetMenu = false;
            goldMineMenu = false;
            wallMenu = false;

            trebuchetUpgradesMap.SetActive(trebuchetMenu);
            goldMineUpgradesMap.SetActive(goldMineMenu);
            wallUpgradesMap.SetActive(wallMenu);
        }
    }

    public void FireArrow()
    {
        if (fireArrowCost <= knowledge)
        {
            player.GetComponent<UpgradeButtons>().fireArrowUnlocked = true;
            knowledge -= fireArrowCost;
            gameObject.SetActive(false);
        }
    }
    public void DoubleShot()
    {
        if (doubleShotCost <= knowledge)
        {
            knowledge -= doubleShotCost;
            player.GetComponent<UpgradeButtons>().doubleShotUnlocked = true;
            gameObject.SetActive(false);
        }
    }


    public void TrebuchetUpgrades()
    {
        trebuchetMenu = !trebuchetMenu;
        trebuchetUpgradesMap.SetActive(trebuchetMenu);

        if (ballistaMenu | goldMineMenu | wallMenu)
        {
            ballistaMenu = false;
            goldMineMenu = false;
            wallMenu = false;

            ballistaUpgradesMap.SetActive(ballistaMenu);
            goldMineUpgradesMap.SetActive(goldMineMenu);
            wallUpgradesMap.SetActive(wallMenu);
        }
    }


    public void GoldMineUpgrades()
    {
        goldMineMenu = !goldMineMenu;
        goldMineUpgradesMap.SetActive(goldMineMenu);

        if (trebuchetMenu | ballistaMenu | wallMenu)
        {
            trebuchetMenu = false;
            ballistaMenu = false;
            wallMenu = false;

            trebuchetUpgradesMap.SetActive(trebuchetMenu);
            ballistaUpgradesMap.SetActive(ballistaMenu);
            wallUpgradesMap.SetActive(wallMenu);
        }
    }


    public void WallUpgrades()
    {
        wallMenu = !wallMenu;
        wallUpgradesMap.SetActive(wallMenu);

        if (trebuchetMenu | goldMineMenu | ballistaMenu)
        {
            trebuchetMenu = false;
            goldMineMenu = false;
            ballistaMenu = false;

            trebuchetUpgradesMap.SetActive(trebuchetMenu);
            goldMineUpgradesMap.SetActive(goldMineMenu);
            ballistaUpgradesMap.SetActive(ballistaMenu);
        }
    }

}