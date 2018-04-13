using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionSouris : MonoBehaviour {

	//Fait apparaitre le curseur de la souris
	void Start () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
	

}
