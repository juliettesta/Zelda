using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {

    public GameObject Start;
    public GameObject Instructions;

    public void ChangeScene( string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

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
    public void quitterJeu()
    {
        Application.Quit();
    }


}
