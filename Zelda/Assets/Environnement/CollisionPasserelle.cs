using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPasserelle : MonoBehaviour
{
    //Permet de garder la passerelle entre la salle 2 et la salle des pilliers
    // visible pendant 4s, après elle disparait
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
