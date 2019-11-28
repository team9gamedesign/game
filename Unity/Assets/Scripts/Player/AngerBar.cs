using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerBar : MonoBehaviour
{ 
    public Image angerBar;
    float maxAnger;
    float currentAnger;

    // Start is called before the first frame update
    void Start()
    {
        //angerBar = GameObject.Find("angerBarPlayer").GetComponent<Slider>(); //TODO: Fix
        maxAnger = GetComponent<Stats>().maxAnger;
        currentAnger = GetComponent<Stats>().anger;

        angerBar.fillAmount = currentAnger / maxAnger;
    }

    // Update is called once per frame
    void Update()
    {
        currentAnger = GetComponent<Stats>().anger;
        angerBar.fillAmount = currentAnger / maxAnger;
    }
}
