using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterStats : MonoBehaviour {

    //permet de sauvegarder les stats d'un personnage/monstre

    public double maxEnergie;
    public double actuelEnergie { get; set; }

    void Start()
    {
        actuelEnergie = maxEnergie;
    }

    //Définie la manière dont le personnnage perd ses points de vie
    public void takeDamage(double damage)
    {
        actuelEnergie = actuelEnergie - damage;
        if (actuelEnergie <= 0)
        {
            die();
        }
    }

    public virtual void die()
    {
    }
}
