﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAttack : MonoBehaviour {

    public BoxCollider box;
    private float startTime = 0.0f;

    // Use this for initialization
    void Start () {
        box = GetComponent<BoxCollider>();
        box.enabled = false;
        startTime = Time.time;
    }


// Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            startTime = Time.time;
            box.enabled = true;
            //Debug.Log("Collider Epee ON");
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
