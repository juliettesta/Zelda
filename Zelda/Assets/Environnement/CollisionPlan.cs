using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlan : MonoBehaviour {

    //Permet d'afficher le plan du labyrinthe quand le Player s'approche de Plan
    public GameObject Plan;
    public Transform player;

    public float distanceDetect = 2.0F;
    public bool detecter;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CalculDist();
        if (detecter)
        {
            Plan.SetActive(true);
        }
        else
        {
            Plan.SetActive(false);
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
