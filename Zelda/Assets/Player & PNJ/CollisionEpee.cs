using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEpee : MonoBehaviour {

    //Permet au Player de récupérer l'épée si c'est possible

    public Transform player;
    public float distanceDetect = 1.0F;
    public bool detecter;


    public GameObject pnjMaison;
    public GameObject pierreEntree;

    CollisionPNJMaison pnjCollision;
    PlayerStats joueur;

    // Use this for initialization
    void Start () {
        pnjCollision = pnjMaison.GetComponent<CollisionPNJMaison>();
        joueur = player.GetComponent<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update () {
        if (pnjCollision.recupEpeePossible)
        {
            CalculDist();
            if (detecter)
            {
                joueur.possedeEpee = true;
                pnjCollision.epeeObtenu = true;
                Destroy(gameObject);
                Destroy(pierreEntree);
            }
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
