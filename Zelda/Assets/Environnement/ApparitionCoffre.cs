using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionCoffre : MonoBehaviour {

    //permet de faire apparaitre le coffre dans la salle 2, quand tous les monstres sont morts
    public GameObject basCoffre;
    public GameObject hautCoffre;
    public GameObject porte;

    public GameObject salle2;
    public int nbrmonstre;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Récupère le nombre d'éléments des monstres de la salle 2
        Transform[] trs = salle2.GetComponentsInChildren<Transform>(true); 
        nbrmonstre = trs.Length;
        //Il ne reste que le gameobject vide des monstres de la salle 2
        if (nbrmonstre == 1)
        {
            basCoffre.SetActive(true);
            hautCoffre.SetActive(true);
            if (porte != null)  Destroy(porte);
        }
    }
}
