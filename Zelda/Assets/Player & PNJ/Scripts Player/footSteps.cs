using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footSteps : MonoBehaviour {

    //Controle du son des pas du Player

    private CharacterController cc;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        //Quand le personnage est au sol, il marche et que le son ne joue pas
		if (cc.isGrounded && cc.velocity.magnitude>1f && GetComponent<AudioSource>().isPlaying == false && !Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<AudioSource>().volume = Random.Range(0.7f, 1f);
            GetComponent<AudioSource>().pitch = Random.Range(1f, 1.1f);
            GetComponent<AudioSource>().Play();
        }
        //Si le personnage court
        if (cc.isGrounded && cc.velocity.magnitude > 1f && GetComponent<AudioSource>().isPlaying == false && Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<AudioSource>().volume = Random.Range(0.6f, 0.8f);
            GetComponent<AudioSource>().pitch = Random.Range(1.5f, 1.6f);
            GetComponent<AudioSource>().Play();
        }
	}
}
