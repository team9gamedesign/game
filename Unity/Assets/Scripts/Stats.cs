﻿using System.Collections;
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

    //Gun Mage stats
    public int maxHeat;
    [HideInInspector]
    public int heat;

    private void Start()
    {
        health = maxHealth;
        damageTaken = new List<float>();
    }

    public void ChangeHealth(float value) {
        if(value < 0)
        {
            if(punchingBag && berserkerMode)
            {
                value = -value;
            } else
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

    public void ChangeHeat(int value)
    {
        heat = Mathf.Clamp(heat + value, 0, maxHeat);
    }
}
