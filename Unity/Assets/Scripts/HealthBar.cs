using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Insert healthBar
    public Image healthBar;

    float maxHealth;
    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        //Retrieve maxHealth and currentHealth to appropriately set healthBar filling
        maxHealth = GetComponent<Stats>().maxHealth;
        currentHealth = GetComponent<Stats>().health;

        healthBar.fillAmount = currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Update healthBar filling
        currentHealth = GetComponent<Stats>().health;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
