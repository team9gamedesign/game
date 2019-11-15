using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerSlider : MonoBehaviour
{ 
    public Slider angerBar;

    // Start is called before the first frame update
    void Start()
    {
        angerBar = GameObject.Find("angerBarPlayer").GetComponent<Slider>(); //TODO: Fix
        angerBar.maxValue = GetComponent<Stats>().maxAnger;
        angerBar.value = GetComponent<Stats>().anger;
    }

    // Update is called once per frame
    void Update()
    {
        angerBar.value = GetComponent<Stats>().anger;
    }
}
