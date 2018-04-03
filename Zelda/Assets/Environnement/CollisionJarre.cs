using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionJarre : MonoBehaviour {

    public GameObject coeur;

    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "PlayerArme")
        {
            int rdn = Random.Range(0, 10);
            if (rdn < 8)
            {
                coeur.SetActive(true);
            }
            Destroy(gameObject);
            //Debug.Log("aléatoire : " + rdn);
        }
    }
}
