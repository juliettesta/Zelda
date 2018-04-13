using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

    //Permet de sauvegarder les stats du Player d'une scène à l'autre
    public static GlobalControl Instance;

    public bool possedeCle = false;
    public bool possedeEpee = false;
    public bool possedeBaton = false;
    public bool estDansTemple = false;
    public bool enVie = true;

    public double maxEnergie = 5;
    public double actuelEnergie = 5;
    public double maxCoeur = 5;


    void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    
}
