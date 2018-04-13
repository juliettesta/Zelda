using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersStats : characterStats
{
    //Regroupe les caractéristiques du monstre
    public GameObject corpsMonstre;
    public Shader standard;
    public Shader texture;
    public bool monstreRouge = false;

    void Start()
    {
        actuelEnergie = maxEnergie;
        standard = Shader.Find("Standard");
        texture = Shader.Find("Unlit/Texture");
    }

    // Peut etre attaqué par le Player de 0 à 10 dégats, il devient rouge à chaque dégats
    public void estAttaque()
    {
        int damage = Random.Range(0, 11);
        takeDamage(damage);
        if (corpsMonstre != null)
        {
            corpsMonstre.GetComponent<SkinnedMeshRenderer>().material.shader = standard;
            monstreRouge = true;
        }
    }

    //le monstre disparait quand il meurt
    public override void die()
    {
        Destroy(gameObject);
    }
}
