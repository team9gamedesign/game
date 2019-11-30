using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAbility : MonoBehaviour
{
    void Start()
    {
        Animator enemyAnimator = GetComponent<Ability>().user.GetComponent<Animator>();
        enemyAnimator.SetTrigger("Charge");
        Destroy(gameObject);
    }
}
