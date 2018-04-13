using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBoss : MonoBehaviour {

    //Permet de contrôler la barre de vie du Boss
    public GameObject Boss;
    MonstersStats stats;
    private Image healthbar;

    void Start()
    {
        stats = Boss.GetComponent<MonstersStats>();
        healthbar = GetComponent<Image>();
    }

    void Update()
    {
        double nbr = stats.actuelEnergie / 100;
        healthbar.fillAmount = (float)nbr;

        if (nbr >= 0.6) healthbar.color = new Color32(9, 143, 10, 250);
        else if (nbr < 0.6 && nbr > 0.3) healthbar.color = new Color32(255, 114, 6, 250);
        else if (nbr <= 0.3) healthbar.color = new Color32(204, 6, 6, 250);
    }
}
