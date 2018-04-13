using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementMonstre : MonoBehaviour {

    //Animation du monstre suivant ses actions
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
        //Le monstre attaque toutes les 2 et 4s
        if (attack)
        {
            if (startTime + temps < Time.time)
            {
                anim.SetTrigger("Attack");
                attackEffectuee = true;
                startTime = Time.time;
                temps = Random.Range(2, 4);
            }
            else
            {
                miseEnAttente();
            }
        }
        //le monstre détecte et suit le Joueur
        else if (poursuite)
        {
            mouvement();
        }
        //le monstre ne "voit" plus le joueur
        else if (poursuite == false)
        {
            miseEnAttente();
        }

    }


    private void mouvement()
    {
        Debug.DrawLine(player.transform.position, maTransform.position, Color.blue);
        anim.SetBool("Walk", true);
        agent.destination = player.position;//le monstre se dirige vers le joueur
    }

    //L'ennemi reste a sa position actuelle
    private void miseEnAttente()
    {
        anim.SetBool("Walk", false);
        agent.destination = transform.position;
    }
}
