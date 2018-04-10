using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Research : MonoBehaviour
{
    public Transform holdPoint;
    GameObject player;
    bool isHolding;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
        if (isHolding)
        {
            transform.position = holdPoint.transform.position;
            player.GetComponentInChildren<Flamethrower>();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        isHolding = true;
    }
}