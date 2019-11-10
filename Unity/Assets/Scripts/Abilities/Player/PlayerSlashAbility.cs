using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlashAbility : MonoBehaviour
{
    void Start() {
        Animator animator = GetComponent<Ability>().user.GetComponent<Animator>();
        animator.SetBool("Slash", true);
        Destroy(gameObject);
    }
}
