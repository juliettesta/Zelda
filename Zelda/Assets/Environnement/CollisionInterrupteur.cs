using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInterrupteur : MonoBehaviour {


    //Permet d'activer la passerelle entre la salle 2 et la salle des pilliers
    //Verifie que le Player ne se trouve pas là où doit apparaitre la passerelle
    public GameObject rond;
    public bool passerelle = false;

    public GameObject cylindre;


    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "PlayerArme" && !cylindre.GetComponent<CollisionPasserelleTrou>().dessus)
        {
            passerelle = true;
            rond.SetActive(true);
            rond.GetComponent<CollisionPasserelle>().startTime = Time.time;
        }
    }
}
