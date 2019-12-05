using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
        playingBerserker = ClassStorage.instance.usingBerserker;
        player = Instantiate(playingBerserker ? Berserker : GunMage, transform.position, Quaternion.identity);
        DontDestroyOnLoad(player);
    }

    [HideInInspector]
    public GameObject player;

    public GameObject GunMage;
    public GameObject Berserker;

    [HideInInspector]
    public bool playingBerserker;
}
