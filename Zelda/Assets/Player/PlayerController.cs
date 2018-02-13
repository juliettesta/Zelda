using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int walkSpeed = 5;
    public int runSpeed = 10;
    public int turnSpeed = 10;
    private Vector3 directionDeplacement = Vector3.zero;
    private CharacterController player;
    public int jump = 5;
    public int gravite = 20;
    public Animator anim;

	// Use this for initialization
	void Start () {
        player = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

        //Déplacement

        if (player.isGrounded)
        {
            directionDeplacement = new Vector3(0, 0, Input.GetAxis("Vertical"));
            directionDeplacement = transform.TransformDirection(directionDeplacement);
            if (Input.GetKey(KeyCode.X))
            {
                directionDeplacement *=runSpeed;
            }
            else
            {
                directionDeplacement *= walkSpeed;
            }

            if (Input.GetKeyDown(KeyCode.Space) && player.isGrounded)
            {
                directionDeplacement.y = jump;
                anim.SetTrigger("Jump");

            }
        }
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);
        player.Move(directionDeplacement * Time.deltaTime);
        
        /*directionDeplacement.z = Input.GetAxisRaw("Vertical") ;
        //directionDeplacement.x = Input.GetAxisRaw("Horizontal");
        //transform.Rotate(0, Input.GetAxisRaw("Horizontal"), 0);
        directionDeplacement = transform.TransformDirection(directionDeplacement);

        // Vitesse de déplacement
        if (Input.GetKey(KeyCode.X))
        {
            player.Move(directionDeplacement * Time.deltaTime * runSpeed);
        }
        else
        {
            player.Move(directionDeplacement * Time.deltaTime * walkSpeed);
        }*/


        /*if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);*/


        //Saut
        /*if (Input.GetKeyDown(KeyCode.Space)&& player.isGrounded)
        {
            directionDeplacement.y = jump;
            anim.SetTrigger("Jump");

        }*/

        //Gravite
        if (!player.isGrounded) directionDeplacement.y -= gravite * Time.deltaTime;

        //Marcher
        if (Input.GetKey(KeyCode.W) & !Input.GetKey(KeyCode.X))
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Run", false);
        }
        //Courrir
        if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.X))
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
        }
        //On revient à l'arrêt
        if (!Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }
    }
}
