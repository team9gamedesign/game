using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float speed;
    public float globalCDValue;

    public float maxGravity;
    [HideInInspector]
    public float gravity;

    //Berserker stats
    public int maxAnger;
    [HideInInspector]
    public int anger;
    [HideInInspector]
    public bool berserkerMode;
    public float angerIncreaseTime;
    public int angerIncreaseAmount;
    public float angerDecreaseTime;
    public int angerDecreaseAmount;
    [HideInInspector]
    public List<float> damageTaken;
    [HideInInspector]
    public bool punchingBag;
    [HideInInspector]
    public float punchingBagTimer;
    [HideInInspector]
    public int punchingBagAngerAmount;
    [HideInInspector]
    public bool bullRush;
    [HideInInspector]
    public float bullRushTimer;
    public float bullRushSpeedFactor;
    public float bullRushDamage;
    [HideInInspector]
    public bool blocking;
    [HideInInspector]
    public int blockAmount;

    //Combinations
    [HideInInspector]
    public int doubleUpFactor = 1;

    private void Start()
    {
        health = maxHealth;
        damageTaken = new List<float>();
    }

    public void ChangeHealth(float value) {
        if(value < 0)
        {
            if (punchingBag && berserkerMode)
            {
                value = -value;
            }
            else if (blocking && blockAmount > 0)
            {
                value = -value;
                blockAmount--;
                blocking = blockAmount != 0;
            }
            else
            {
                damageTaken.Add(-value);
            }
            
        }
        health = Mathf.Clamp(health + value, 0, maxHealth);
    }

    public void ChangeAnger(int value)
    {
        anger = Mathf.Clamp(anger + value, 0, maxAnger);
    }
}
