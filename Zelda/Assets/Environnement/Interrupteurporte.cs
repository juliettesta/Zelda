using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interrupteurporte : MonoBehaviour {

    //Fait tomber la porte de la salle 2 et fait apparaitre les monstres
    // Lorsque le Player entre dans la pièce, c-a-d marche sur l'interrupteur
    public GameObject porte;
    public GameObject monstres;

    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            if (porte != null) porte.GetComponent<Rigidbody>().useGravity = true;
            if (monstres != null)
            {
                monstres.SetActive(true);
            }
            
        }
    }
}
