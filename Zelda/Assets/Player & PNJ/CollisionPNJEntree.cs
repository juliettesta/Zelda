using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionPNJEntree : MonoBehaviour {


    //Permet d'afficher un texte sur l'écran lorsque le Player s'approche du PNJ
       //Le texte change si le Player possede l'épée
    public string parole = "";
    public GameObject fond;
    public GameObject texte;
    public Transform player;

    Text txt;

    public float distanceDetect = 2.0F;
    public bool detecter;

    PlayerStats playerstats;

    // Use this for initialization
    void Start () {
        playerstats = player.GetComponent<PlayerStats>();
        txt = texte.GetComponent<UnityEngine.UI.Text>();
    }
	
	// Update is called once per frame
	void Update () {
        CalculDist();
        if (detecter)
        {
            if (playerstats.possedeEpee)
            {
                txt.text = "Fais attention gamin, personne n'est jamais revenu du temple de cristal!!";
                texte.SetActive(true);
                fond.SetActive(true);
            }        
            else
            {
                txt.text = parole;
                texte.SetActive(true);
                fond.SetActive(true);
            }
        }
        else
        {
            texte.SetActive(false);
            fond.SetActive(false);
        }
    }

    private void CalculDist()
    {
        //Le joueur est a ditance
        if (player)
        {
            float sqrLen = (player.position - transform.position).sqrMagnitude;
            if (sqrLen < distanceDetect * distanceDetect)
            {
                detecter = true;

                if (IsInvoking("Timer"))//Annule l'invocation au cas d'une invocation déjà effectué
                {
                    CancelInvoke("Timer");
                }
            }
            //Le joueur n'est plus a distance
            if (sqrLen > distanceDetect && detecter)
            {
                detecter = false;
            }
        }
    }
}
