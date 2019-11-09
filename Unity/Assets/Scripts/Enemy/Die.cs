using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
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
            Destroy(gameObject);
        }
    }
}
