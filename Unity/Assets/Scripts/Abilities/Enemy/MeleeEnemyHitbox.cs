using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (other.gameObject == player)
        {
            player.GetComponent<Stats>().ChangeHealth(-1);
            Destroy(gameObject);
        }
    }
}
