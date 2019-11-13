using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    Abilities abilities;
    Stats stats;

    [HideInInspector]
    public float globalCD = 0;

    // Start is called before the first frame update
    protected void Start()
    {
        abilities = GetComponent<Abilities>();
        stats = GetComponent<Stats>();
    }

    protected void UseAbility(int abilityIndex)
    {
        GameObject abilityPrefab = abilities.abilities[abilityIndex];
        if (abilityPrefab.GetComponent<Ability>().usesGlobalCD && Mathf.Approximately(globalCD, 0))
        {
            if (Mathf.Approximately(abilities.abilityCooldowns[abilityIndex], 0))
            {
                GameObject ability = Instantiate(abilityPrefab, transform.position, transform.rotation);
                ability.GetComponent<Ability>().user = gameObject;
                globalCD += stats.globalCDValue;
                abilities.abilityCooldowns[abilityIndex] = ability.GetComponent<Ability>().cooldown;
            }
        }
        else if (!abilityPrefab.GetComponent<Ability>().usesGlobalCD)
        {
            if (Mathf.Approximately(abilities.abilityCooldowns[abilityIndex], 0))
            {
                GameObject ability = Instantiate(abilityPrefab, transform.position, transform.rotation);
                ability.GetComponent<Ability>().user = gameObject;
                abilities.abilityCooldowns[abilityIndex] = ability.GetComponent<Ability>().cooldown;
            }
        }
    }
}
