using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPasserelle : MonoBehaviour
{

    public float startTime = 0.0f;
    public GameObject interrupteur;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (interrupteur.GetComponent<CollisionInterrupteur>().passerelle)
        {
            if (startTime + 4 < Time.time)
            {
                interrupteur.GetComponent<CollisionInterrupteur>().passerelle = false;
                gameObject.SetActive(false);
            }

        }
    }
}
