using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour {

    //Detruit la balle lorsqu'elle entre en collision
    void OnCollisionEnter(Collision Col)
    {
        Destroy(gameObject);
    }
}
