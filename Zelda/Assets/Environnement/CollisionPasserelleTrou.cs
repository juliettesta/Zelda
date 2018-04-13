using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPasserelleTrou : MonoBehaviour {

    //Permet de voir si le Player est à l'endroit ou doit apparaitre la passerelle ou non
    public bool dessus = false;

    void OnCollisionEnter(Collision Col)
    {

        if (Col.gameObject.tag == "Player")
        {
            dessus = true;
        }
    }
    void OnCollisionExit(Collision Col)
    {

        if (Col.gameObject.tag == "Player")
        {
            dessus = false;
        }
    }

}
