using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InstructionScreen : MonoBehaviour
{

	void Start ()
    {

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
	
	void Update ()
    {
		
	}

    public void OnClick()
    {
        Application.LoadLevel("Test Level");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}