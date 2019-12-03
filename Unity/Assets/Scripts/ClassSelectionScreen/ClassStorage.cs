using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassStorage : MonoBehaviour
{
    public static ClassStorage instance;

    void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }

    [HideInInspector]
    public bool usingBerserker;
}
