using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickAbility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Ability>().user.GetComponent<Animator>();
        Stats stats = GetComponent<Ability>().user.GetComponent<Stats>();
        animator.SetInteger("Kick", stats.doubleUpFactor);
        stats.doubleUpFactor = 1;
        Destroy(gameObject);
    }
}
