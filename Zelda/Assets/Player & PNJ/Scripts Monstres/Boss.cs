using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    //Permet de rendre l'apparence normal du monstre une fois qu'il est touché
    MonstersStats stats;
    private float startTime = 0.0f;

    // Use this for initialization
    void Start () {
        stats = GetComponent<MonstersStats>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (stats.monstreRouge)
        {
            stats.monstreRouge = false;
            startTime = Time.time;
        }
        if (startTime + 0.1 < Time.time)
        {
            stats.corpsMonstre.GetComponent<SkinnedMeshRenderer>().material.shader = stats.texture;
        }
      }
}
