using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrupteurBoss : MonoBehaviour {

    //public bool jeuGagnee = false;
    public GameObject porte;

	void OnCollisionEnter (Collision Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            porte.SetActive(true);
        }
    }
}
