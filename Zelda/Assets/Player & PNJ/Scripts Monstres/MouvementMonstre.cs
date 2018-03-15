using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementMonstre : MonoBehaviour {

    public Transform player;
    private Transform maTransform;
    private UnityEngine.AI.NavMeshAgent agent;
    public bool poursuite = false;
    public bool pause = true;
    public bool attack = false;
    public bool attackEffectuee = false;
    public Animator anim;
    private float startTime = 0.0f;
    int temps = 3;


    void Awake()
    {
        maTransform = transform;
    }

    // Use this for initialization
    void Start()
    {

        //Initialisation du script NavMeshAgent qui se trouve sur le même objet que ce script
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        pause = false;
        anim = GetComponent<Animator>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {
            if (startTime + temps < Time.time)
            {
                attackEffectuee = true;
                anim.SetTrigger("Attack");
                startTime = Time.time;
                temps = Random.Range(2, 4);
            }
            else
            {
                miseEnAttente();
            }
        }
        else if (poursuite)
        {
            mouvement();
        }
        else if (poursuite == false)
        {
            miseEnAttente();
        }

    }


    private void mouvement()
    {
        Debug.DrawLine(player.transform.position, maTransform.position, Color.blue);
        anim.SetBool("Walk", true);
        agent.destination = player.position;//le squelette se dirige vers le joueur
    }

    //L'ennemi reste a sa position actuelle
    private void miseEnAttente()
    {
        //Debug.Log("arret ok");
        anim.SetBool("Walk", false);
        agent.destination = transform.position;
    }


}
