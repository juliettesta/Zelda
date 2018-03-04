using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirMonstre : MonoBehaviour {

    public GameObject Projectile;
    public int force = 20;
    public bool attack = false;
    public GameObject target;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (attack)
        {
            GameObject Bullet = Instantiate(Projectile, target.transform.position, Quaternion.identity) as GameObject;
            Bullet.GetComponent<Rigidbody>().velocity = transform.forward * force; //transform.TransformDirection(Vector3.forward) *force
            Destroy(Bullet, 3f); //Destruction des balles après 3s
        }
    }
}
