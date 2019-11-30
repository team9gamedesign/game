using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleUpCombinationAbility : MonoBehaviour
{
    public int doubleUpFactor = 2;
    // Start is called before the first frame update
    void Start()
    {
        Stats stats = GetComponent<Ability>().user.GetComponent<Stats>();
        stats.doubleUpFactor = doubleUpFactor;
        Destroy(gameObject);
    }
}
