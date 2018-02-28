using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersStats : characterStats
{

    public MonstersStats(int maxE) : base(maxE) { }

    void OnCollisionEnter(Collision Col)
    {
        Debug.Log("collision monstre ok");
        //Destroy(gameObject);
    } 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
