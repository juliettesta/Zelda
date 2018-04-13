using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cle : MonoBehaviour {

    //Permet de faire tomber la clé si les 6 pilliers sont activés dans le bon ordre

    public bool p1;
    public bool p2;
    public bool p3;
    public bool p4;
    public bool p5;
    public bool p6;

    public int num;

    // Use this for initialization
    void Start () {
        initialiser();
    }
	
	// Update is called once per frame
	void Update () {

        //Active le booléen si le bon pillier est activé
        if (num == 1 && !p2 && !p3 && !p4 && !p5 && !p6)
        {
            p1 = true;
        }
        if (num == 2 && p1 && !p3 && !p4 && !p5 && !p6)
        {
            p2 = true;
        }
        if (num == 3 && p1 && p2 && !p4 && !p5 && !p6)
        {
            p3 = true;
        }
        if (num == 4 && p1 && p2 && p3 && !p5 && !p6)
        {
            p4 = true;
        }
        if (num == 5 && p1 && p2 && p3 && p4 && !p6)
        {
            p5 = true;
        }
        if (num == 6 && p1 && p2 && p3 && p4 && p5)
        {
            p6 = true;
        }

        //La clé tombe si tous les pilliers sont activés dans le bon ordre
        if (p1 && p2 && p3 && p4 && p5 && p6)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
	}

    //Initialise tous les booléens à false
    public void initialiser()
    {
        p1 = false;
        p2 = false;
        p3 = false;
        p4 = false;
        p5 = false;
        p6 = false;
        num = 0;
    }
}
