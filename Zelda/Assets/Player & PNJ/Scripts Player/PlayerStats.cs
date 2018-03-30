using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : characterStats {

    public bool possedeCle = false;
    public bool possedeEpee = false;
    public bool possedeBaton = false;
    public bool estDansTemple = false;
    public bool enVie = true;

    public double maxCoeur; // sauvegarde le nombre de gros coeur affiché à l'écran

    //Elements de l'interface
    public GameObject epee;
    public GameObject epeeTrans;
    public GameObject baton;
    public GameObject batonTrans;
    public GameObject cle;
    public GameObject cleTrans;
    public GameObject coeur;
    public GameObject coeurDemi;
    public GameObject coeurTrans;

    public GameObject parentCanvas;

    

    void Start()
    {
        actuelEnergie = maxEnergie;
        maxCoeur = maxEnergie;
        //Création de la vie maxmimale
        for (int i = 0; i < maxEnergie; i++)
        {
            coeur.transform.position = new Vector3(25.7F + 40 * i, 300F, 0F);
            GameObject newCoeurTrans = Instantiate(coeurTrans, coeur.transform.position, Quaternion.identity) as GameObject;
            newCoeurTrans.transform.SetParent(parentCanvas.transform);
            newCoeurTrans.name = "coeurTrans" + (i + 1);
        }
        // Création de la vie actuelle
        //Demi coeur
        for (int i = 0; i < actuelEnergie; i++)
        {
            coeur.transform.position = new Vector3(25.7F + 40 * i, 300F, 0F);
            GameObject newCoeurDemi = Instantiate(coeurDemi, coeur.transform.position, Quaternion.identity) as GameObject;
            newCoeurDemi.transform.SetParent(parentCanvas.transform);
            newCoeurDemi.name = "coeurDemi" + (i + 1);
        }
        //Coeur entier
        for (int i = 0; i < actuelEnergie; i++)
        {
            coeur.transform.position = new Vector3(25.7F + 40 * i, 300F, 0F);
            GameObject newCoeur = Instantiate(coeur, coeur.transform.position, Quaternion.identity) as GameObject;
            newCoeur.transform.SetParent(parentCanvas.transform);
            newCoeur.name = "coeur" + (i + 1);
        }


        // Recupération des données
        possedeCle = GlobalControl.Instance.possedeCle;
        possedeEpee = GlobalControl.Instance.possedeEpee;
        possedeBaton = GlobalControl.Instance.possedeBaton;
        estDansTemple = GlobalControl.Instance.estDansTemple;
        enVie = GlobalControl.Instance.enVie;
        maxEnergie = GlobalControl.Instance.maxEnergie;
        actuelEnergie = GlobalControl.Instance.actuelEnergie;
        maxCoeur = GlobalControl.Instance.maxCoeur;

       
    }

    //Permet de sauver les variables du player dans le GlobalControl
    public void SavePlayer()
    {
        GlobalControl.Instance.possedeCle = possedeCle;
        GlobalControl.Instance.possedeEpee = possedeEpee;
        GlobalControl.Instance.possedeBaton = possedeBaton;
        GlobalControl.Instance.estDansTemple = estDansTemple;
        GlobalControl.Instance.enVie = enVie;
        GlobalControl.Instance.maxEnergie = maxEnergie;
        GlobalControl.Instance.actuelEnergie = actuelEnergie;
        GlobalControl.Instance.maxCoeur = maxCoeur;
    }

    void Update()
    { 
        if (enVie)
        {
            //Nbr de Gros coeur
            if (maxCoeur == maxEnergie - 1)
            {
                //L'énergie du player est au maximum
                for (int i = 0; i < maxCoeur; i++)
                {
                    GameObject coeurDesac = PlayerCollision.FindObject(parentCanvas, "coeur" + (i + 1));
                    coeurDesac.SetActive(true);
                    GameObject coeurTransDesac = PlayerCollision.FindObject(parentCanvas, "coeurTrans" + (i + 1));
                    coeurTransDesac.SetActive(true);
                    GameObject coeurDemiDesac = PlayerCollision.FindObject(parentCanvas, "coeurDemi" + (i + 1));
                    coeurDemiDesac.SetActive(true);
                }

                //Ajout d'un nouveau coeur

                //Coeur trans
                coeur.transform.position = new Vector3(25.7F + 40 * (float)maxCoeur, 300F, 0F);
                GameObject newCoeurTrans = Instantiate(coeurTrans, coeur.transform.position, Quaternion.identity) as GameObject;
                newCoeurTrans.transform.SetParent(parentCanvas.transform);
                newCoeurTrans.name = "coeurTrans" + (maxCoeur + 1);
                //Demi coeur
                coeur.transform.position = new Vector3(25.7F + 40 * (float)maxCoeur, 300F, 0F);
                GameObject newCoeurDemi = Instantiate(coeurDemi, coeur.transform.position, Quaternion.identity) as GameObject;
                newCoeurDemi.transform.SetParent(parentCanvas.transform);
                newCoeurDemi.name = "coeurDemi" + (maxCoeur + 1);
                //Coeur entier
                coeur.transform.position = new Vector3(25.7F + 40 * (float)maxCoeur, 300F, 0F);
                GameObject newCoeur = Instantiate(coeur, coeur.transform.position, Quaternion.identity) as GameObject;
                newCoeur.transform.SetParent(parentCanvas.transform);
                newCoeur.name = "coeur" + (maxCoeur + 1);

                maxCoeur = maxEnergie;
            }
        }
        

        // Armes et Cle
        if (possedeEpee) epeeTrans.SetActive(true);
        else
        {
            epeeTrans.SetActive(false);
            epee.SetActive(false);
        }
        if (possedeBaton) batonTrans.SetActive(true);
        else
        {
            batonTrans.SetActive(false);
            baton.SetActive(false);
        }
        if (estDansTemple && !possedeCle) cleTrans.SetActive(true);
        else
        {
            cleTrans.SetActive(false);
            cle.SetActive(false);
        }
        if (possedeCle) cle.SetActive(true);
        else
        {
            cle.SetActive(false);
        }



    }
    public void estAttaque()
    {
        if (enVie)
        {
            takeDamage(0.5);
            //JOUER LE SON
            //Affichage
            if (actuelEnergie % 1 == 0) // Si la vie actuelle est entière
            {
                GameObject coeurDesac = GameObject.Find("coeurDemi" + (actuelEnergie + 1));
                coeurDesac.SetActive(false);
            }
            else // la vie a actuelle à 0.5
            {
                GameObject coeurDesac = GameObject.Find("coeur" + (actuelEnergie + 0.5));
                coeurDesac.SetActive(false);
            }
        }   
    }

    public override void die()
    {
        enVie = false;
        //SON QUAND IL MEURT
        //Afficher GAME OVER
        //JOUER l'ANIMATION MORT
        //FRISER LES ACTIONS  + proposer quitter le jeu ou recommencer
        Debug.Log(gameObject.name + "meurt");
    }

}
