using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierAbility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Ability>().user.GetComponent<Animator>();
        animator.SetTrigger("Barrier");
        Destroy(gameObject);
    }
}
