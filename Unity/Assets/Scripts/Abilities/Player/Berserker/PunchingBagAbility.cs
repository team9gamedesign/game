﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBagAbility : MonoBehaviour
{
    public float punchingBagTimer = 10.0f;
    public int punchingBagAngerAmount = 5;
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Ability>().user.GetComponent<Animator>();
        animator.SetTrigger("PunchingBag");
        Stats stats = GetComponent<Ability>().user.GetComponent<Stats>();
        stats.punchingBag = true;
        stats.punchingBagTimer = punchingBagTimer;
        stats.punchingBagAngerAmount = punchingBagAngerAmount;
        Destroy(gameObject);
    }
}
