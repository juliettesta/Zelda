using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    PlayerStats player;

    void Start()
    {
        player = GetComponent<PlayerStats>();
        //Debug.Log("Player possede " + player.maxEnergie);
    }
    void Update()
    {
        
    }

    
    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "MonstreArme")
        {
            player.estAttaque();
            Debug.Log("Le monstre a touché le joueur, il lui reste " + player.actuelEnergie);
        }
        else if (Col.gameObject.tag == "Cle")
        {
                player.nbrCle += 1;
                //AFFICHER ECRAN
                Destroy(gameObject);
        }
        else if (Col.gameObject.tag == "Coeur")
        {
            if (player.actuelEnergie + 1 <= player.maxEnergie) player.actuelEnergie += 1;
            else player.actuelEnergie = player.maxEnergie;
            // AFFICHER A L'ECRAN LES COEURS
            Destroy(gameObject);
        }
        else if (Col.gameObject.tag == "GrosCoeur")
        {
            player.maxEnergie += 1;
            player.actuelEnergie = player.maxEnergie;
            //AFFICHER ECRAN
            Destroy(gameObject);
        }
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
