using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    float maxHealth;
    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        //healthBar = GameObject.Find("healthBarPlayer").GetComponent<Slider>(); //TODO: Fix
        maxHealth = GetComponent<Stats>().maxHealth;
        currentHealth = GetComponent<Stats>().health;

        healthBar.fillAmount = currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = GetComponent<Stats>().health;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
