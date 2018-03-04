using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterStats : MonoBehaviour {

    public double maxEnergie;
    public double actuelEnergie { get; set; }

    void Start()
    {
        actuelEnergie = maxEnergie;
    }

    public void takeDamage(double damage)
    {
        actuelEnergie -= damage;
        //Debug.Log(gameObject.name + " prend " + damage + " dégats");
        if (actuelEnergie <= 0)
        {
            die();
        }
    }

    public virtual void die()
    {
        //Les monstres disparaissent
        // Le joueur meurt et affichage de gameover
        Debug.Log(gameObject.name + " meurt");
    }
}
