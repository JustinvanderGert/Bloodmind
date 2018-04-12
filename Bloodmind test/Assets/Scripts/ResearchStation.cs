using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResearchStation : MonoBehaviour
{
    public int knowledge;
    public GameObject ResearchScreen;
    GameObject player;
    bool inMenu = false;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inMenu = false;
        }

        if (inMenu)
        {
            ResearchScreen.SetActive(true);
        }
        else
        {
            ResearchScreen.SetActive(false);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inMenu = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inMenu = false;
        }
    }
}