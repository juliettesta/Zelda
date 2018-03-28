using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChgmtSceneStart : MonoBehaviour {


    PlayerStats player;

    void start()
    {
        player = GetComponent<PlayerStats>();
    }
    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "Player")

        {
            player.SavePlayer();
            SceneManager.LoadScene("Temple");  
        }
        
    }
        
    }
       
