using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = GetComponent<Stats>().maxHealth;
        healthBar.value = GetComponent<Stats>().health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = GetComponent<Stats>().health;
    }
}
