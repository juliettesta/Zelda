using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCoffre : MonoBehaviour {

    //Active l'ouverture du coffre script "openChest" si le joueur attaque le coffre
    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "PlayerArme")
        {
            gameObject.GetComponent<OpenChest>().opening = true;
            
        }
    }
}
