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
            if (startTime + 1 < Time.time)
            {
                startTime = Time.time;
                player.estAttaque();
                Debug.Log("Le monstre a touché le joueur, il lui reste " + player.actuelEnergie);
            }

        }
        if (Col.gameObject.tag == "eau") // Il perd un demi points de vie, à chaque fois qu'il va dans l'eau
        {
            if (startTime + 5 < Time.time)
            {
                startTime = Time.time;
                player.estAttaque();
                //Debug.Log("Le joueur est dans l'eau, il lui reste " + player.actuelEnergie);
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

        //A VERIFIER

        else if (Col.gameObject.tag == "Epee")
        {
            //sera dans un coffre ou par terre ?
                //Ajout aux objets pouvant être utilisé
                //Appuyer sur a pour changer d'arme (aide)
            Destroy(gameObject);

        }
        else if (Col.gameObject.tag == "Baton")
        {
            // Sera dans un coffre
                //Ajout aux armes pouvant etre utilisé
                //appuyer sur a pour changer d'arme (aide)
            Destroy(gameObject);
        }
        else if (Col.gameObject.tag == "Coffre")
        {
            //Ouvrir coffre (animation + son)
            //Faire apparait l'objet
            //Incrémenté l'inventaire, actions suivant objet, coeur, groscoeur ou clé, clé bosse
            //Afficher texte "Wow tu as trouvé nom du tag de l'objet"
            //Le joueur appuie sur entré ou une touche?
            //Faire disparaitre l'objet
            
            /*objet.SetActive(true);
            if (objet.name == "cle")
            {
                nbrCle += 1;
                Destroy(objet, 5f);
                //AFFICHER ECRAN + objet disparait apres quelques secondes
            }
            else if (objet.name == "grosCoeur")
            {
                maxEnergie += 1;
                actuelEnergie = maxEnergie;
                //AFFICHER ECRAN 
                Destroy(objet, 5f);
            }*/
        }
        /*else if (Col.gameObject.tag == "CleBoss")
        {

        }*/
    }
}
