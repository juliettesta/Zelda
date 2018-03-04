using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstreCollision : MonoBehaviour {

    MonstersStats monstre;
    //AMELIORATION : Le monstre est touché que quand le player attaque et non juste touché par l'arme

    // Use this for initialization
    void Start () {
        monstre = GetComponent<MonstersStats>();
        //Debug.Log("Monstre possede " + monstre.maxEnergie);
    }

    // Update is called once per frame
    void Update () {
        
    }

    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "PlayerArme")
        {
            monstre.estAttaque();
            Debug.Log("Monstre touché, reste " + monstre.actuelEnergie);
        }
    }
}
