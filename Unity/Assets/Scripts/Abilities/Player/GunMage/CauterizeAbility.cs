using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauterizeAbility : MonoBehaviour
{
    public GameObject sound;
    public float healAmount = 30f;
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Ability>().user.GetComponent<Animator>();
        animator.SetTrigger("Cauterize");
        Stats stats = GetComponent<Ability>().user.GetComponent<Stats>();
        stats.ChangeHealth(healAmount * stats.doubleUpFactor);
        stats.doubleUpFactor = 1;

        GameObject soundObject = Instantiate(sound);
        Destroy(soundObject, 5f);

        Destroy(gameObject);
    }
}
