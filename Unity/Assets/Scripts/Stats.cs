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

    private void Start()
    {
        health = maxHealth;
    }

    public void ChangeHealth(float value) {
        health = Mathf.Clamp(health + value, 0, maxHealth);
    }

    public void ChangeAnger(int value)
    {
        anger = Mathf.Clamp(anger + value, 0, maxAnger);
    }
}
