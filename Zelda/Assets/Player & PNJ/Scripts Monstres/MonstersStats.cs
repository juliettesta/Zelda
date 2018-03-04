using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersStats : characterStats
{
 
    //Si le monstre meurt, il disparait pendant un certain moment

    public void estAttaque()
    {
        //JOUER LE SON
        int damage = Random.Range(0, 11);
        takeDamage(damage);
        
    }

    public override void die()
    {
        // SON QUAND IL MEURT
        // JOUER l'ANIMATION MORT puis il disparait apres quelques secondes
        Destroy(gameObject);
        Debug.Log(gameObject.name + " meurt");
    }
}
