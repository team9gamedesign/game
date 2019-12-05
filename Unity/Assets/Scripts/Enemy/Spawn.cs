using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;

    private float timer;
    public float spawnTime;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

        player = GameObject.FindWithTag("Player"); //TODO: Fix so we don't look for tags
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnTime) {
            timer = 0;
            GameObject enemySpawned = Instantiate(enemy, transform.position, Quaternion.identity, null);
            //enemySpawned.GetComponent<FollowPlayer>().player = player;
        }
    }
}
