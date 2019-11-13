using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PommelAbility : MonoBehaviour
{
    void Start() {
        Animator animator = GetComponent<Ability>().user.GetComponent<Animator>();
        animator.SetTrigger("Pommel");
        Destroy(gameObject);
    }
}
