using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMageAttackHandler : AttackHandler
{
    Animator animator;

    new void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.health <= 0)
        {
            animator.SetBool("Death", true);
            return;
        }

        globalCD = Mathf.Max(0, globalCD - Time.deltaTime);

        if(!stats.laser)
        {
            //Ability handling
            if (Input.GetKey(KeyCode.Alpha1))
            { //Button 1
                UseAbility(2);
            }
            if (Input.GetKey(KeyCode.Alpha2))
            { //Button 2
                UseAbility(3);
            }
            if (Input.GetKey(KeyCode.Alpha3))
            { //Button 3
                UseAbility(4);
            }
            if (Input.GetKey(KeyCode.Alpha4))
            { //Button 4
                UseAbility(5);
            }
            if (Input.GetMouseButton(1))
            { //Right mouse button
                UseAbility(1);
            }
            if (Input.GetMouseButton(0))
            { //Left mouse button
                UseAbility(0);
            }
        }
    }
}
