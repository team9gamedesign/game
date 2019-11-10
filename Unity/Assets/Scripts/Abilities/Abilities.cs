using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public List<GameObject> abilities;
    [HideInInspector]
    public List<float> abilityCooldowns;

    // Start is called before the first frame update
    void Start()
    {
        abilityCooldowns = new List<float>();
        for(int i = 0; i < abilities.Count; ++i) {
            abilityCooldowns.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < abilityCooldowns.Count; ++i) {
            abilityCooldowns[i] = Mathf.Max(0, abilityCooldowns[i] - Time.deltaTime);
        }
    }
}
