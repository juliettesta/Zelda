using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCoffre : MonoBehaviour {

    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "PlayerArme")
        {
            gameObject.GetComponent<OpenChest>().opening = true;
            
        }
    }
}
