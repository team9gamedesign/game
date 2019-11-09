using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    Abilities abilities;
    
    public float globalCD = 0;
    public float globalCDValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        abilities = GetComponent<Abilities>();
    }

    // Update is called once per frame
    void Update()
    {
        globalCD = Mathf.Max(0, globalCD - Time.deltaTime);

        if(Input.GetKey(KeyCode.Alpha1)) { //Button 1

        }
        if(Input.GetKey(KeyCode.Alpha2)) { //Button 2

        }
        if(Input.GetKey(KeyCode.Alpha3)) { //Button 3

        }
        if(Input.GetKey(KeyCode.Alpha4)) { //Button 4

        }
        if(Input.GetMouseButton(1)) { //Right mouse button

        }
        if(Input.GetMouseButton(0)) { //Left mouse button
            GameObject abilityPrefab = abilities.abilities[0];
            if(abilityPrefab.GetComponent<Ability>().usesGlobalCD && Mathf.Approximately(globalCD, 0)) {
                if(Mathf.Approximately(abilities.abilityCooldowns[0], 0)) {
                    GameObject ability = Instantiate(abilityPrefab, transform.position, transform.rotation);
                    ability.GetComponent<Ability>().user = gameObject;
                    globalCD += globalCDValue;
                    abilities.abilityCooldowns[0] = ability.GetComponent<Ability>().cooldown;
                }
            } else if(!abilityPrefab.GetComponent<Ability>().usesGlobalCD) {
                if(Mathf.Approximately(abilities.abilityCooldowns[0], 0)) {
                    GameObject ability = Instantiate(abilityPrefab, transform.position, transform.rotation);
                    ability.GetComponent<Ability>().user = gameObject;
                    abilities.abilityCooldowns[0] = ability.GetComponent<Ability>().cooldown;
                }
            }
        }
    }
}
