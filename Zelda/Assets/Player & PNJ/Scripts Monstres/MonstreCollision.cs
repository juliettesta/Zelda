using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstreCollision : MonoBehaviour {

    //Permet de détecter les collision entre l'arme du player et le monstre
    MonstersStats monstre;
    private float startTime = 0.0f;

    // Use this for initialization
    void Start () {
        monstre = GetComponent<MonstersStats>();
        startTime = Time.time;
    }
    void Update()
    {

    }

    //Le joueur peut attaquer le monstre toutes les 0.4s
    void OnCollisionEnter(Collision Col)
    {
       
        if (Col.gameObject.tag == "PlayerArme")
        {
            if (startTime + 0.4 < Time.time)
            {
                startTime = Time.time;
                monstre.estAttaque();
                //Debug.Log("Monstre touché, reste " + monstre.actuelEnergie);
            }
        }
    }
}
