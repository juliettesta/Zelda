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
    public Animator anim;
    private float startTime = 0.0f;
    int temps = 3;

    private TirMonstre tir;

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
        tir = GetComponent<TirMonstre>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {
            if (startTime + temps < Time.time)
            {
                anim.SetTrigger("Attack");
                tir.attack = true;
                startTime = Time.time;
                temps = Random.Range(2, 4);
            }
            else
            {
                miseEnAttente();
                tir.attack = false;
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
