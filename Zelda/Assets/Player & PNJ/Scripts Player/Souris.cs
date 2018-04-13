using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Souris : MonoBehaviour {

    //Permet de cacher le curseur de la souris lorsqu'on joue, echappe pour la faire apparaitre.
	
        // Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
	}
}
