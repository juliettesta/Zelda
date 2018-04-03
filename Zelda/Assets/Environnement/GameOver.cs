using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject player;
    public GameObject gameover;
    public GameObject quitter;
	
	// Update is called once per frame
	void Update () {
		if (!player.GetComponent<PlayerStats>().enVie)
        {
            gameover.SetActive(true);
            quitter.SetActive(true);
        }
	}
}
