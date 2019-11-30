using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject user = GetComponent<Ability>().user;
        Animator animator = user.GetComponent<Animator>();
        Stats stats = user.GetComponent<Stats>();
        animator.SetInteger("Shoot", stats.doubleUpFactor);
        stats.doubleUpFactor = 1;
        Destroy(gameObject);
    }
}
