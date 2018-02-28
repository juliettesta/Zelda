using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterStats : MonoBehaviour {

    public double maxEnergie;
    public double actuelEnergie { get; protected set; }

    public characterStats(int maxE)
    {
        maxEnergie = maxE;
        actuelEnergie = maxE;
    }

    public void takeDamage(double damage)
    {
        actuelEnergie -= damage;
        Debug.Log(transform.name + " takes " + damage);
        if (actuelEnergie <= 0)
        {
            die();
        }
    }

    public virtual void die()
    {
        //Les monstres disparaisses
        // Le joueur meur et affichage de gameover
        Debug.Log(transform.name + " die");
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
