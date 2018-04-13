using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {

    //Permet au personnage de tirer avec le baton magique, création des balles
    public GameObject Projectile;
    public int force = 20;
    public AudioClip sonTir;
    public GameObject baton;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {  

        if (Input.GetButtonDown("Fire1") && baton.activeSelf == true)
        {
            GetComponent<AudioSource>().PlayOneShot(sonTir);
            GameObject Bullet = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
            Bullet.GetComponent<Rigidbody>().velocity = transform.forward * force; 
            Destroy(Bullet,3f); //Destruction des balles après 3s
        }
    }

}
