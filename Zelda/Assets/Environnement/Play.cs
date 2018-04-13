using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {

    //Différentes fonctions permettant des actions sur l'écran
    public GameObject Start;
    public GameObject Instructions;

    //Permet de changer de scene
    public void ChangeScene( string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Permet d'afficher les isntructions du jeu
    public void instructions(bool afficher)
    {
        if (afficher)
        {
            Start.SetActive(false);
            Instructions.SetActive(true);

        }
        else
        {
            Start.SetActive(true);
            Instructions.SetActive(false);
        }
               
    }
    //Permet de quitter le jeu
    public void quitterJeu()
    {
        Application.Quit();
    }


}
