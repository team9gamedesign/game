using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    Abilities abilities;
    protected Stats stats;

    [HideInInspector]
    public float globalCD;

    // Start is called before the first frame update
    protected void Start()
    {
        abilities = GetComponent<Abilities>();
        stats = GetComponent<Stats>();
    }

    protected void UseAbility(int abilityIndex)
    {
        if(abilityIndex >= abilities.abilities.Count)
        {
            return;
        }

        GameObject abilityPrefab = abilities.abilities[abilityIndex];
        Ability abilityComponent = abilityPrefab.GetComponent<Ability>();

        if (abilityComponent.requiresLevel && stats.level < abilityComponent.levelRequirement)
        {
            return;
        }

        bool canUseAbility = false;

        if (abilityComponent.usesGlobalCD && Mathf.Approximately(globalCD, 0))
        {
            canUseAbility |= Mathf.Approximately(abilities.abilityCooldowns[abilityIndex], 0);
        }
        else if (!abilityComponent.usesGlobalCD)
        {
            canUseAbility |= Mathf.Approximately(abilities.abilityCooldowns[abilityIndex], 0);
        }

        if(canUseAbility)
        {
            //Check if berserker mode is needed
            if (abilityComponent.requiresBerserkerMode && !stats.berserkerMode)
            {
                return;
            }

            //Check if anger is needed and how much, but only check if not in berserker mode
            if (!stats.berserkerMode)
            {
                if (abilityComponent.angerNeeded > 0)
                {
                    if (stats.anger < abilityComponent.angerNeeded)
                    {
                        return;
                    }
                    stats.ChangeAnger(-abilityComponent.angerNeeded);
                }
            }

            //Check if heat is needed
            if(abilityComponent.heatNeeded > 0)
            {
                if(stats.heat < abilityComponent.heatNeeded)
                {
                    return;
                }
                stats.ChangeHeat(-abilityComponent.heatNeeded);
            }

            GameObject ability = Instantiate(abilityPrefab, transform.position, transform.rotation);
            ability.GetComponent<Ability>().user = gameObject;

            CountDown countDown = GameObject.Find("CountDownHandler").GetComponent<CountDown>(); //TODO: This causes a bug when enemies use it. Remove and put somewhere else!
            if (abilityComponent.usesGlobalCD)
            {
                globalCD = stats.globalCDValue;
                countDown.CDSliders[abilityIndex].value = globalCD;
            }
            abilities.abilityCooldowns[abilityIndex] = ability.GetComponent<Ability>().cooldown;
            countDown.CDSliders[abilityIndex].value = Mathf.Max(countDown.CDSliders[abilityIndex].value, ability.GetComponent<Ability>().cooldown);
        }
    }
}
