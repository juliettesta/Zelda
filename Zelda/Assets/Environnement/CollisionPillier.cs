using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPillier : MonoBehaviour {

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
