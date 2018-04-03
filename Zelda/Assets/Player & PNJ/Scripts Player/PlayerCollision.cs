using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    PlayerStats player;
    private float startTime = 0.0f;

    void Start()
    {
        player = GetComponent<PlayerStats>();
        startTime = Time.time;
        //Debug.Log("Player possede " + player.maxEnergie);
    }
    void Update()
    {
        
    }

    public static GameObject FindObject ( GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }
    
    void OnCollisionEnter(Collision Col)
    {
        //Debug.Log("Collision personnage");
        if (Col.gameObject.tag == "MonstreArme")
        { 
            if (startTime + 1.9 < Time.time)
            {
                startTime = Time.time;
                player.estAttaque();
                Debug.Log("Joueur touché, il lui reste " + player.actuelEnergie);
            }

        }
        if (Col.gameObject.tag == "eau") // Il perd un demi points de vie toutes les 5s
        {
            if (startTime + 5 < Time.time)
            {
                startTime = Time.time;
                player.estAttaque();
                //Debug.Log("Le joueur est dans l'eau, il lui reste " + player.actuelEnergie);
            }     
        }
        if (Col.gameObject.tag == "Trou") // Il perd un demi points de vie toutes les secondes (Trou + Lave)
        {
            if (startTime + 1 < Time.time)
            {
                startTime = Time.time;
                player.estAttaque();   
            }
        }
        else if (Col.gameObject.tag == "Coeur")
        {
            //Debug.Log("Collision coeur ok");
            if (player.actuelEnergie + 1 <= player.maxEnergie) player.actuelEnergie += 1;
            else player.actuelEnergie = player.maxEnergie;
            
            //Affichage
            if (player.enVie) { 
                if (player.actuelEnergie % 1 == 0) // Si la vie actuelle est entière
                {
                    GameObject coeurDesac = FindObject(player.parentCanvas, "coeurDemi" + (player.actuelEnergie));
                    coeurDesac.SetActive(true);
                    GameObject coeurDesac2 = FindObject(player.parentCanvas, "coeur" + (player.actuelEnergie));
                    coeurDesac2.SetActive(true);
                }
                else // la vie a actuelle à 0.5
                {
                    GameObject coeurDesac = FindObject(player.parentCanvas, "coeur" + (player.actuelEnergie - 0.5));
                    coeurDesac.SetActive(true);
                    GameObject coeurDesac2 = FindObject(player.parentCanvas, "coeurDemi" + (player.actuelEnergie + 0.5));
                    coeurDesac2.SetActive(true);
                }
            }
            
            //Destruction coeur
            Destroy(Col.gameObject);
        }
        else if (Col.gameObject.tag == "Groscoeur")
        {
            player.maxEnergie += 1;
            //Debug.Log("Collision Gros coeur ok : " + player.maxEnergie);
            player.actuelEnergie = player.maxEnergie;
            Destroy(Col.gameObject);
        }
        else if (Col.gameObject.tag == "chgmtScene")
        {
            player.SavePlayer();
        }
        else if (Col.gameObject.tag == "Baton")
        {
            player.possedeBaton = true;
            Destroy(Col.gameObject);
        }
        else if (Col.gameObject.tag == "Cle")
        {
            player.possedeCle = true;
            Destroy(Col.gameObject);
        }
       

        
    }
}
