using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAbility : MonoBehaviour
{
    public int blockAmount = 3;
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Ability>().user.GetComponent<Animator>();
        animator.SetTrigger("PunchingBag");
        Stats stats = GetComponent<Ability>().user.GetComponent<Stats>();
        stats.blocking = true;
        stats.blockAmount = blockAmount;
        Destroy(gameObject);
    }
}
