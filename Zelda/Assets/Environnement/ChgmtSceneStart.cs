using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChgmtSceneStart : MonoBehaviour {

    //Active le message de chargement et va vers la scène "Temple" 
    public GameObject chargement;
    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "Player")

        {
            chargement.SetActive(true);
            SceneManager.LoadScene("Temple");  
        }
        
    }
        
    }
       
