using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChgmtSceneStart : MonoBehaviour {

    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "Player")

        {
            SceneManager.LoadScene("Temple");  
        }
        
    }
        
    }
       
