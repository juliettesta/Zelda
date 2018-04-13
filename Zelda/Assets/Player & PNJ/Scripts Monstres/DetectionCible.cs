using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCible : MonoBehaviour {

    //Permet au monstre de détecter le Player dans une zone plus ou moins proche

    private Transform cible;
    public float distanceDetect = 6.0F;
    public float distanceAttack = 1.0F;
    public bool detecter; 
    public float decroche = 2; // temps après lequel l'ennemi arrête de suivre le player lorsqu'il est hors champ
    private MouvementMonstre sComportement;

    // Use this for initialization
    void Start()
    {
        sComportement = GetComponent<MouvementMonstre>();
        cible = sComportement.player;
    }

    // Update is called once per frame
    void Update()
    {
        CalculDist();
    }

    //Verifie la position du joueur
    private void CalculDist()
    {
        //Le joueur est a ditance
        if (cible)
        {
            float sqrLen = (cible.position - transform.position).sqrMagnitude;
            if (distanceAttack * distanceAttack <= sqrLen && sqrLen < distanceDetect * distanceDetect)
            {
                detecter = true;
                sComportement.pause = false;
                sComportement.poursuite = true;
                sComportement.attack = false;

                if (IsInvoking("Timer"))//Annule l'invocation au cas d'une invocation déjà effectué
                {
                    CancelInvoke("Timer");
                }
            }
            //Le joueur n'est plus a distance
            if (sqrLen > distanceDetect && detecter)
            {
                detecter = false;
                PlusAdistance();
            }  
            if (distanceAttack * distanceAttack > sqrLen && detecter)
            {
                sComportement.pause = true;
                sComportement.poursuite = false;
                sComportement.attack = true;
            }

        }
    }

    //Appel la methode coroutine "Timer"
    private void PlusAdistance()
    {
        //Permet d'utilisé un temps donné avant d'arreter la poursuite et appel la méthode "finPoursuite"
        Invoke("finPoursuite", decroche);
    }

    //Met fin a la poursuite du joueur
    private void finPoursuite()
    {
        sComportement.pause = true;
        sComportement.poursuite = false;
        sComportement.attack = false;
    }
}
