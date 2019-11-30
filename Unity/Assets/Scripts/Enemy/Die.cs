using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public int xp;

    Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.health <= 0)
        {
            PlayerManager.instance.player.GetComponent<Stats>().xp += xp;
            Destroy(gameObject);
        }
    }
}
