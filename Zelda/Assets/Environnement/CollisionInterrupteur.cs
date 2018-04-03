using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInterrupteur : MonoBehaviour {

    //private float startTime = 0.0f;
    public GameObject rond;
    public bool passerelle = false;


	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "PlayerArme")
        {
            passerelle = true;
            rond.SetActive(true);
            rond.GetComponent<CollisionPasserelle>().startTime = Time.time;
        }
    }
}
