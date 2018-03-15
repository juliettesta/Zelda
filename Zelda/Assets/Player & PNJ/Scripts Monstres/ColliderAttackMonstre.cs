using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAttackMonstre : MonoBehaviour {

    private CapsuleCollider box;
    public GameObject monstre;
    private MouvementMonstre mvtMonstre;
    private float startTime = 0.0f;

    // Use this for initialization
    void awake()
    {
        box = GetComponent<CapsuleCollider>();
        mvtMonstre = monstre.GetComponent<MouvementMonstre>();
        box.enabled = false;
        startTime = Time.time;
    }
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (mvtMonstre.attackEffectuee == true)
        {
            startTime = Time.time;
            box.enabled = true;
            Debug.Log("Collider ARME ON");
        }
        else
        {
            if (startTime + 1 < Time.time && box.enabled == true)
            {
                box.enabled = false;
                //Debug.Log("Collider terminé");
            }
        }

    }
}
