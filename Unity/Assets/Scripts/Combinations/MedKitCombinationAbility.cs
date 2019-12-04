using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitCombinationAbility : MonoBehaviour
{
    public int healAmount = 20;
    // Start is called before the first frame update
    void Start()
    {
        Stats stats = GetComponent<Ability>().user.GetComponent<Stats>();
        stats.ChangeHealth(healAmount);
        Destroy(gameObject);
    }
}
