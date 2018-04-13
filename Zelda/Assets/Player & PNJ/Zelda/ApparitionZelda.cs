using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionZelda : MonoBehaviour {

    //Lorque le Boss est mort, le jeu est gagné, Zelda apparait

    public GameObject Boss;
    public GameObject Zelda;
    public GameObject Effet;
    public GameObject barreBoss;
    public GameObject lumiere;


	// Update is called once per frame
	void Update () {
		
        if (Boss == null)
        {
            lumiere.GetComponent<AudioSource>().mute = true;
            Zelda.SetActive(true);
            Effet.SetActive(true);
            Destroy(barreBoss);
        }
        if (Zelda.activeSelf) GetComponent<AudioSource>().mute = false;
	}
}
