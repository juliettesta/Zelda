using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionZelda : MonoBehaviour {

    //Accès à la fin du jeu, lorsque le Player s'approche de Zelda
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
            SceneManager.LoadScene("Fin");
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
