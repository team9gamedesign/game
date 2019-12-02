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

    private Stats stats;
    private int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLevel != stats.level)
        {
            currentLevel = stats.level;
            //Retrieve maxHealth and currentHealth to appropriately set healthBar filling
            maxHealth = stats.maxHealth;
            currentHealth = stats.health;
        }

        //Update healthBar filling
        currentHealth = stats.health;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
