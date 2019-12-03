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
        player = Instantiate(playingGunMage ? GunMage : Berserker, transform.position, Quaternion.identity);
        DontDestroyOnLoad(player);
    }

    [HideInInspector]
    public GameObject player;

    public GameObject GunMage;
    public GameObject Berserker;
    public bool playingGunMage;
}
