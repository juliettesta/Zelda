using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierreEntree : MonoBehaviour {

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
