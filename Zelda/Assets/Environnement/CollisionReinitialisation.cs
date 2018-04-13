using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionReinitialisation : MonoBehaviour {

    public GameObject cle;
    public GameObject parentPilliers;

    //Permet de faire apparaitre tous les pilliers et réinitialiser les booléens
    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "PlayerArme")
        {
            if (cle != null)
            {
                cle.GetComponent<Cle>().initialiser();
            }

            Transform[] trs = parentPilliers.GetComponentsInChildren<Transform>(true);
            for (int i=0; i< trs.Length; i++)
            {
                trs[i].gameObject.SetActive(true);
            }

        }
    }

}
