using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAbility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject user = GetComponent<Ability>().user;
        Animator animator = user.GetComponent<Animator>();
        animator.SetTrigger("Laser");
        user.GetComponent<Stats>().laser = true;
        Destroy(gameObject);
    }
}
