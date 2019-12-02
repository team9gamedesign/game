using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttackAbility : MonoBehaviour
{
    void Start()
    {
        Animator enemyAnimator = GetComponent<Ability>().user.GetComponent<Animator>();
        enemyAnimator.SetBool("Attack", true);
        Destroy(gameObject);
    }
}
