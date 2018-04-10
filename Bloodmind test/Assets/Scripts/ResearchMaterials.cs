using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchMaterials : MonoBehaviour
{
    public Transform holdPoint;
    GameObject player;
    GameObject flameThrower;
    public bool isHolding = false;
    bool pickedUp = false;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        flameThrower = GameObject.FindGameObjectWithTag("Flamethrower");
        holdPoint = player.transform.Find("HoldPoint");
	}
	
	void Update ()
    {
        if (isHolding)
        {
            transform.position = holdPoint.transform.position;
            flameThrower.SetActive(false);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player") && !pickedUp)
        {
            transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
            isHolding = true;
            pickedUp = true;
        }
        if(other.gameObject.tag == ("Research_Station"))
        {
            other.gameObject.GetComponent<ResearchStation>().knowledge++;
            isHolding = false;
            flameThrower.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}