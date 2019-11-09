using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttackHandler : MonoBehaviour
{
    Abilities abilities;
    GameObject player;

    [HideInInspector]
    public float globalCD;
    public float globalCDValue = 1;

    void Start()
    {
        abilities = GetComponent<Abilities>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        globalCD = Mathf.Max(0, globalCD - Time.deltaTime);
        if (Random.Range(0, 1) <= 0.1f && Vector3.Distance(transform.position, player.transform.position) <= 25)
        {
            UseAbility(0);
        }
    }

    void UseAbility(int abilityIndex)
    {
        GameObject abilityPrefab = abilities.abilities[abilityIndex];
        if (abilityPrefab.GetComponent<Ability>().usesGlobalCD && Mathf.Approximately(globalCD, 0))
        {
            if (Mathf.Approximately(abilities.abilityCooldowns[0], 0))
            {
                GameObject ability = Instantiate(abilityPrefab, transform.position, transform.rotation);
                ability.GetComponent<Ability>().user = gameObject;
                globalCD += globalCDValue;
                abilities.abilityCooldowns[0] = ability.GetComponent<Ability>().cooldown;
            }
        }
        else if (!abilityPrefab.GetComponent<Ability>().usesGlobalCD)
        {
            if (Mathf.Approximately(abilities.abilityCooldowns[0], 0))
            {
                GameObject ability = Instantiate(abilityPrefab, transform.position, transform.rotation);
                ability.GetComponent<Ability>().user = gameObject;
                abilities.abilityCooldowns[0] = ability.GetComponent<Ability>().cooldown;
            }
        }
    }
}
