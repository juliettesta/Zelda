using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : characterStats {

    public int nbrCle = 0;
    public bool epee = false;
    public bool baton = false;

    public void estAttaque()
    {
        takeDamage(0.25);
        //JOUER LE SON
        //ENLEVER UN DEMI COEUR A L'AFFICHAGE ECRAN
    }

    public override void die()
    {
        //SON QUAND IL MEURT
        //Afficher GAME OVER
        //JOUER l'ANIMATION MORT
        //FRISER LES ACTIONS  + proposer quitter le jeu ou recommencer
        //Destroy(gameObject);
        Debug.Log(gameObject.name + "meurt");
    }

}
