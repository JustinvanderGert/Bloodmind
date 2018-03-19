using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float totalGold;
    public Text goldText;

	void Start ()
    {
        goldText.text = "Gold: 0";
    }
	
	void Update ()
    {
        goldText.text = "Gold: " + totalGold;

    }
}