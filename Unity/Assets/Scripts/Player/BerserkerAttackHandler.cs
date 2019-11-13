using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkerAttackHandler : AttackHandler
{
    float angerChangeTimer;

    new void Start()
    {
        base.Start();
        angerChangeTimer = stats.angerIncreaseTime;
    }

    // Update is called once per frame
    void Update()
    {
        globalCD = Mathf.Max(0, globalCD - Time.deltaTime);

        //Phase handling
        if(stats.anger == stats.maxAnger && !stats.berserkerMode)
        {
            stats.berserkerMode = true;
            angerChangeTimer = stats.angerDecreaseTime;

            stats.globalCDValue /= 2;
            stats.speed *= 2;
            GetComponent<Animator>().SetFloat("AnimatorSpeed", 2);
        } else if(stats.anger == 0 && stats.berserkerMode)
        {
            stats.berserkerMode = false;
            angerChangeTimer = stats.angerIncreaseTime;

            stats.globalCDValue *= 2;
            stats.speed /= 2;
            GetComponent<Animator>().SetFloat("AnimatorSpeed", 1);
        }

        if(stats.berserkerMode)
        {
            angerChangeTimer -= Time.deltaTime;
            if (angerChangeTimer <= 0)
            {
                angerChangeTimer = stats.angerDecreaseTime;
                stats.ChangeAnger(-stats.angerDecreaseAmount);
            }
        } else
        {
            angerChangeTimer -= Time.deltaTime;
            if(angerChangeTimer <= 0)
            {
                angerChangeTimer = stats.angerIncreaseTime;
                stats.ChangeAnger(stats.angerIncreaseAmount);
            }
        }

        //Ability handling
        if(Input.GetKey(KeyCode.Alpha1)) { //Button 1
            UseAbility(2);
        }
        if(Input.GetKey(KeyCode.Alpha2)) { //Button 2
            UseAbility(3);
        }
        if(Input.GetKey(KeyCode.Alpha3)) { //Button 3
            UseAbility(4);
        }
        if(Input.GetKey(KeyCode.Alpha4)) { //Button 4
            UseAbility(5);
        }
        if(Input.GetMouseButton(1)) { //Right mouse button
            UseAbility(1);
        }
        if(Input.GetMouseButton(0)) { //Left mouse button
            UseAbility(0);
        }
    }
}
