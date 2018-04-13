using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Permet de controler le déplacement du personnage

    public int walkSpeed = 2;
    public int runSpeed = 5;
    public int turnSpeed = 10;
    private Vector3 directionDeplacement = Vector3.zero;
    private CharacterController player;
    public int gravite = 20;
    public Animator anim;
    //Saut
    public int jumpHigh = 2;
    public AudioClip sonJump;
    //Armes
    public GameObject baton;
    public GameObject epee;
    public AudioClip sonAttackEpee; 

    PlayerStats joueur;


    // Use this for initialization
    void Start() {
        player = GetComponent<CharacterController>();
        joueur =  GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        //Si le personnage est en vie
        if (GetComponent<PlayerStats>().enVie)
        {
            //Déplacement et rotation du personnage          
            if (player.isGrounded)
            {
                directionDeplacement = new Vector3(0, 0, Input.GetAxis("Vertical"));
                directionDeplacement = transform.TransformDirection(directionDeplacement);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    directionDeplacement *= runSpeed;
                }
                else
                {
                    directionDeplacement *= walkSpeed;
                }
            }
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);
            player.Move(directionDeplacement * Time.deltaTime);


            //Changer Armes
            if (joueur.possedeEpee && !joueur.possedeBaton)
            {
                baton.SetActive(false);
                epee.SetActive(true);
                joueur.epee.SetActive(true); // affiche l'épée à l'écran
            }
            else if (joueur.possedeEpee && joueur.possedeBaton)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (epee.activeSelf == true)
                    {
                        baton.SetActive(true);
                        joueur.baton.SetActive(true);
                        epee.SetActive(false);
                        joueur.epee.SetActive(false);
                    }
                    else
                    {
                        baton.SetActive(false);
                        joueur.baton.SetActive(false);
                        epee.SetActive(true);
                        joueur.epee.SetActive(true);
                    }
                }
            }

            //ATTAQUE
            if (Input.GetButtonDown("Fire1"))
            {
                if (baton.activeSelf == true) anim.SetTrigger("AttackB");
                if (epee.activeSelf == true)
                {
                    GetComponent<AudioSource>().PlayOneShot(sonAttackEpee);
                    anim.SetTrigger("AttackE");
                }
            }

            //Saut
            if (Input.GetKeyDown(KeyCode.Space) && player.isGrounded) 
            {
                transform.Translate(Vector3.up * jumpHigh); 
                anim.SetTrigger("Jump");
                GetComponent<AudioSource>().PlayOneShot(sonJump);
            }

            //Gravite
            if (!player.isGrounded) directionDeplacement.y -= gravite * Time.deltaTime;

            //Marcher
            if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
            }
            //Courrir
            if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Run", true);
            }
            //On revient à l'arrêt
            if (!Input.GetKey(KeyCode.Z))
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Run", false);
            }
            //On tourne à droite
            if (Input.GetKey(KeyCode.D))
            {
                anim.SetBool("TurnRight", true);
            }
            else { anim.SetBool("TurnRight", false); }

            //On tourne à gauche
            if (Input.GetKey(KeyCode.Q))
            {
                anim.SetBool("TurnLeft", true);
            }
            else { anim.SetBool("TurnLeft", false); }
        }
        else // Le personnage est mort
        {
            anim.SetBool("Dead", true);
        }
    }    
}
