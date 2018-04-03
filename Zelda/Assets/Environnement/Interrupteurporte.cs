using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interrupteurporte : MonoBehaviour {

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
