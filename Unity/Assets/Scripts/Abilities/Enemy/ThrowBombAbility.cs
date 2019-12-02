using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBombAbility : MonoBehaviour
{
    void Start()
    {
        Animator enemyAnimator = GetComponent<Ability>().user.GetComponent<Animator>();
        enemyAnimator.SetBool("ThrowBomb", true);
        enemyAnimator.SetBool("ShouldMove", false);
        Destroy(gameObject);
    }
}
