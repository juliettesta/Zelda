using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrupteurBoss : MonoBehaviour {

    //Ferme la porte du boss quand le Player est dans la salle, c-a-d marche sur l'interrupteur
    public GameObject porte;
    public GameObject barreVie;

	void OnCollisionEnter (Collision Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            porte.SetActive(true);
            barreVie.SetActive(true);
        }
    }
}
