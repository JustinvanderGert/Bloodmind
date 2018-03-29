using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeBase : MonoBehaviour
{
    public GameObject gameOverScreen;
    public float baseHealth;
    public Text healthText;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        healthText.text = "Base Health: " + baseHealth;

		if(baseHealth <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
            gameOverScreen.SetActive(true);
            SceneManager.LoadScene("Instructions");
            Debug.Log("Game Over");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            baseHealth--;
            other.gameObject.GetComponent<Enemy>().enemyHealth = 0;
        }
        if (other.gameObject.tag == "Heavy_Enemy")
        {
            baseHealth -= 5;
            other.gameObject.GetComponent<Enemy>().enemyHealth = 0;
        }
    }
}