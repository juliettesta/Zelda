using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {

	void awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
