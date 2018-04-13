using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPillier : MonoBehaviour {

    //Si le Player "attaque" un pillier, il disparait
    //Son numéro est transmis au script "cle" pour voir si c'est le bon pillier qui a été activé
    public int numero;
    public GameObject cle;

	void OnCollisionEnter (Collision Col)
    {
        if (Col.gameObject.tag == "PlayerArme")
        {
            if (cle != null)
            {
                cle.GetComponent<Cle>().num = numero;
            }
            gameObject.SetActive(false);

        }
    }
}
