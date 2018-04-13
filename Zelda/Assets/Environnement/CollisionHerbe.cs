using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHerbe : MonoBehaviour {

    public GameObject coeur;
    public GameObject Monstre;
    public GameObject herbe;

	//Si le joueur "coupe" une herbe elle disparait et apparrition d'un monstre ou un coeur ou rien 
    // suivant les probabilités
    void OnCollisionEnter( Collision Col)
    {
        if (Col.gameObject.tag == "PlayerArme")
        {
            int rdn = Random.Range(0, 10);
            if (rdn == 0)
            {
                Monstre.SetActive(true);
            }
            else if (0 < rdn && rdn < 3)
            {
                coeur.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
    
}
