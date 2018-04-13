using UnityEngine;
using System.Collections;

public class OpenChest : MonoBehaviour {

    //Script permettant d'animer l'ouverture du coffre
    //Quand le coffre est ouvert, un objet apparait
    [Range(0.0f, 1.0f)]
    public float factor;

    Quaternion closedAngle;
    Quaternion openedAngle;

    public bool closing;
    public bool opening;
    public GameObject objet;

    public float speed = 0.5f;

    int newAngle = 127;

    // Use this for initialization
    void Start () {
        openedAngle = transform.rotation;
        closedAngle = Quaternion.Euler(transform.eulerAngles + Vector3.right * newAngle);
    }
	
	// Update is called once per frame
	void Update () {

        if (closing)
        {
            factor += speed * Time.deltaTime;

            if (factor > 1.0f)
            {
                factor = 1.0f;
            }
        }
        if (opening)
        {
            factor -= speed * Time.deltaTime;

            if (factor < 0.0f)
            {
                factor = 0.0f;
                if (objet != null)
                {
                    objet.SetActive(true);
                }
            }
        }

        transform.rotation = Quaternion.Lerp(openedAngle, closedAngle, factor);
	}


    void Close()
    {
        closing = true;
        opening = false;
    }

    void Open()
    {
        opening = true;
        closing = false;
    }
}
