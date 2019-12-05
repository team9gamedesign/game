using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public int xp;

    public GameObject[] combinationItems;

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

            foreach(GameObject item in combinationItems)
            {
                if(Random.Range(0f, 1f) <= 0.05f)
                {
                    Instantiate(item, transform.position + Vector3.up, Quaternion.identity);
                    break;
                }
            }

            Destroy(gameObject);
        }
    }
}
