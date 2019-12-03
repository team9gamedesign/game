using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttackHandler : AttackHandler
{

    public bool couldCharge = false;
    GameObject player;
    FollowPlayer myMovementScript;

    new void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player");
        myMovementScript = GetComponent<FollowPlayer>();
    }

    void Update()
    {
        globalCD = Mathf.Max(0, globalCD - Time.deltaTime);
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (globalCD <= 0 &&  distanceToPlayer <= 4f)
        {
            UseAbility(0);
        }
        else if(globalCD <= 0 && distanceToPlayer < myMovementScript.aggroRange && distanceToPlayer > 2.5f)
        {
            if(couldCharge)
            {
                UseAbility(1);
            }
            
        }
    }
}
