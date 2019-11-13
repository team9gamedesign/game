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
    public float gravity = 0;


    private void Start()
    {
        health = maxHealth;
    }

    public void ChangeHealth(float value) {
        health += value;
        health = Mathf.Clamp(health, 0, maxHealth);
    }
}
