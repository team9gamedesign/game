﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttackHandler : AttackHandler
{
    GameObject player;

    new void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        globalCD = Mathf.Max(0, globalCD - Time.deltaTime);
        if (Random.Range(0, 1) <= 0.1f && Vector3.Distance(transform.position, player.transform.position) <= 25)
        {
            UseAbility(0);
        }
    }
}
