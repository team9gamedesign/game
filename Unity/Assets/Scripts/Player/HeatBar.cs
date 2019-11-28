using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatBar : MonoBehaviour
{
    public Image heatBar;
    float maxHeat;
    float currentHeat;

    // Start is called before the first frame update
    void Start()
    {
        //angerBar = GameObject.Find("angerBarPlayer").GetComponent<Slider>(); //TODO: Fix
        maxHeat = GetComponent<Stats>().maxHeat;
        currentHeat = GetComponent<Stats>().heat;

        heatBar.fillAmount = currentHeat / maxHeat;
    }

    // Update is called once per frame
    void Update()
    {
        currentHeat = GetComponent<Stats>().heat;
        heatBar.fillAmount = currentHeat / maxHeat;
    }
}