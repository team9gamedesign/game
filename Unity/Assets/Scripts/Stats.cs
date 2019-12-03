using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float speed;
    public float globalCDValue;

    public float maxGravity;
    [HideInInspector]
    public float gravity;

    public float damageFactor;

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
    
    //Gun Mage stats
    public int maxHeat;
    //[HideInInspector]
    public int heat;
    [HideInInspector]
    public bool barrier;
    [HideInInspector]
    public bool laser;

    public int level = 1;
    [HideInInspector]
    public int xp;
    [HideInInspector]
    public int xpToNextLevel;

    private void Start()
    {
        if(gameObject.CompareTag("Player"))
        {
            SetStatsFromLevel(level);
        } 
        health = maxHealth;
        damageTaken = new List<float>();
    }

    void Update()
    {
        if(gameObject.CompareTag("Player"))
        {
            if(xp >= xpToNextLevel)
            {
                IncreaseLevel();
            }
        }
    }

    public void ChangeHealth(float value) {
        if(value < 0)
        {
            if(barrier)
            {
                return;
            }

            if(punchingBag && berserkerMode)
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

    public void ChangeHeat(int value)
    {
        heat = Mathf.Clamp(heat + value, 0, maxHeat);
    }

    public void SetStatsFromLevel(int level)
    {
        maxHealth = GetHealthFromLevel(level);
        damageFactor = GetDamageFactorFromLevel(level);
        xpToNextLevel = GetXPToNextLevel(level);
    }

    public void IncreaseLevel()
    {
        level += 1;
        xp -= xpToNextLevel;
        SetStatsFromLevel(level);
        health = maxHealth;
    }

    public int GetXPToNextLevel(int level)
    {
        float exponent = 1.5f;
        float baseXP = 1000;
        return (int)Mathf.Floor(baseXP * Mathf.Pow(level, exponent));
    }

    public int GetHealthFromLevel(int level)
    {
        return level * 100;
    }

    public float GetDamageFactorFromLevel(int level)
    {
        return level;
    }
}
