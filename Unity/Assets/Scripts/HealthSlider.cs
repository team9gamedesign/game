using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider healthBar;
    private int currentLevel;
    private Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        healthBar = GameObject.Find("healthBarPlayer").GetComponent<Slider>(); //TODO: Fix
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.level != currentLevel)
        {
            currentLevel = stats.level;
            healthBar.maxValue = stats.GetHealthFromLevel(currentLevel);
        }
        healthBar.value = GetComponent<Stats>().health;
    }
}
