using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float storedCapacity;
    public float storedGold;
    public Text mineContent;
    public float speed;
    GameObject player;

    public float range;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if(storedGold <= storedCapacity)
        {
            storedGold += 1 * speed;
        }
        if (distance <= range)
        {
            mineContent.text = "Collect " + storedGold + " Gold";

            if (Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<Player>().totalGold += storedGold;
                storedGold = 0;
            }
        }else if (distance > range) { mineContent.text = ""; }
	}
}