using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PommelAbility : MonoBehaviour
{
    void Start() {
        Animator animator = GetComponent<Ability>().user.GetComponent<Animator>();
        Stats stats = GetComponent<Ability>().user.GetComponent<Stats>();
        animator.SetInteger("Pommel", stats.doubleUpFactor);
        stats.doubleUpFactor = 1;
        Destroy(gameObject);
    }
}
