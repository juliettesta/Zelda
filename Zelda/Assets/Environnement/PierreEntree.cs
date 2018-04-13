using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierreEntree : MonoBehaviour {


    //Fait disparaitre la Pierre de l'entrée (permettant d'acceder au Temple) si le player possede l'épée
    public GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        
        if (player.GetComponent<PlayerStats>().possedeEpee)
        {
            gameObject.SetActive(false);
        }
    }
}
