using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionCoffre : MonoBehaviour {

    public GameObject basCoffre;
    public GameObject hautCoffre;

    public GameObject salle2;
    public int nbrmonstre;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Transform[] trs = salle2.GetComponentsInChildren<Transform>(true);
        nbrmonstre = trs.Length;
        if (nbrmonstre == 1)
        {
            basCoffre.SetActive(true);
            hautCoffre.SetActive(true);
        }
    }
}
