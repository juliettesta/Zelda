using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHerbe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    void OnCollisionEnter( Collision Col)
    {
        if (Col.gameObject.tag == "PlayerArme")
        {
            Destroy(Col.gameObject);
            Debug.Log("Herbe détruite");
        }
    }
    
}
