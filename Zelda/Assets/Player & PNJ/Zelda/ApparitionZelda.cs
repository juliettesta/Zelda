using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionZelda : MonoBehaviour {

    public GameObject Boss;
    public GameObject Zelda;
    public GameObject Effet;


	// Update is called once per frame
	void Update () {
		
        if (Boss == null)
        {
            Zelda.SetActive(true);
            Effet.SetActive(true);
        }
	}
}
