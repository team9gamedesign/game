using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyShootAbility : MonoBehaviour
{
    void Start()
    {
        Animator enemyAnimator = GetComponent<Ability>().user.GetComponent<Animator>();
        enemyAnimator.SetBool("Shoot", true);
        Destroy(gameObject);
    }
}
