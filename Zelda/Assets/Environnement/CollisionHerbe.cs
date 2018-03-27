using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHerbe : MonoBehaviour {

    public GameObject coeur;
    public GameObject Monstre;
    public GameObject herbe;

	
    void OnCollisionEnter( Collision Col)
    {
        if (Col.gameObject.tag == "PlayerArme")
        {
            int rdn = Random.Range(0, 10);
            if (rdn == 0)
            {
                Monstre.SetActive(true);
            }
            else if (0 < rdn && rdn < 4)
            {
                coeur.SetActive(true);
            }
            Destroy(gameObject);
            //Debug.Log("aléatoire : " + rdn);
        }
    }
    
}
