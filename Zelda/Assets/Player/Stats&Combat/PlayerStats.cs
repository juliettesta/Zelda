using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : characterStats {

    public int nbrCle = 0;
    public List<GameObject> armes = new List<GameObject>();

    public PlayerStats(int maxE) : base(maxE) { }

    void OnCollisionEnter(Collision Col)
    {
        Debug.Log("collision sur le bonhomme ok");
        //Destroy(gameObject);
    }

    //Si le monstre "voit" le joueur, il l'attaque, s'approche si besoin
    //Si le monstre est touché par le joueur, il perd des dégats avec un aléatoire
    //Si le monstre meurt, il disparait pendant un certain moment

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void estAttaque()
    {
        takeDamage(0.5);
        //JOUER LE SON
        //ENLEVER UN DEMI COEUR A L'AFFICHAGE ECRAN
    }

    public override void die()
    {
        //Afficher GAME OVER
        //JOUER l'ANIMATION MORT
        Debug.Log(transform.name + " die");
    }

    public void ramasser(GameObject objet)
    {
        if (objet.name == "cle")
        {
            nbrCle += 1;
            //AFFICHER ECRAN
        }
        else if (objet.name == "Coeur")
        {
            if (actuelEnergie + 1 <= maxEnergie) actuelEnergie += 1;
            else actuelEnergie = maxEnergie;
            // AFFICHER A L'ECRAN LES COEURS

        }
        else if (objet.name == "grosCoeur")
        {
            maxEnergie += 1;
            actuelEnergie = maxEnergie;
            //AFFICHER ECRAN 
        }
        Destroy(objet);
    }

    public void ouvrirCoffre(GameObject objet)
    {
        objet.SetActive(true);
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
        }
    }

}
