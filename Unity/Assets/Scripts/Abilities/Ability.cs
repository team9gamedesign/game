using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public bool usesGlobalCD = true;
    public float cooldown = 10;
    [HideInInspector]
    public GameObject user;

    public bool requiresBerserkerMode;
    public int angerNeeded;

    public int heatNeeded;
}
