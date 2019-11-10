using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightningAbility : MonoBehaviour
{
    void Start()
    {
        Animator animator = GetComponent<Ability>().user.GetComponent<Animator>();
        animator.SetBool("Lightning", true);
        Destroy(gameObject);
    }
}
