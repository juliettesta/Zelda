using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour {


    void OnCollisionEnter(Collision Col)
    {
        //Debug.Log("collision ok");
        Destroy(gameObject);
    }
}
