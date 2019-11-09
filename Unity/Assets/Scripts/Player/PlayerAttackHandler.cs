using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHandler : AttackHandler
{
    // Update is called once per frame
    void Update()
    {
        globalCD = Mathf.Max(0, globalCD - Time.deltaTime);

        if(Input.GetKey(KeyCode.Alpha1)) { //Button 1
            UseAbility(2);
        }
        if(Input.GetKey(KeyCode.Alpha2)) { //Button 2

        }
        if(Input.GetKey(KeyCode.Alpha3)) { //Button 3

        }
        if(Input.GetKey(KeyCode.Alpha4)) { //Button 4

        }
        if(Input.GetMouseButton(1)) { //Right mouse button
            UseAbility(1);
        }
        if(Input.GetMouseButton(0)) { //Left mouse button
            UseAbility(0);
        }
    }
}
