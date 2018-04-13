using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    // Si le Player n'est plus en vie, le jeu est perdu
        //Apparition du curseur, du gameover et propose de quitter le jeu
    public GameObject player;
    public GameObject gameover;
    public GameObject quitter;
	
	// Update is called once per frame
	void Update () {
		if (!player.GetComponent<PlayerStats>().enVie)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameover.SetActive(true);
            quitter.SetActive(true);
        }
	}
}
