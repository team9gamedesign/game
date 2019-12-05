using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float aliveTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, aliveTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Stats>().barrier = true;
        }
    }

    void OnDestroy()
    {
        GameObject player = PlayerManager.instance.player;
        Vector3 playerXZ = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        Vector3 thisXZ = new Vector3(transform.position.x, 0, transform.position.z);
        if(Vector3.Distance(playerXZ, thisXZ) <= GetComponent<SphereCollider>().radius * transform.localScale.x)
        {
            player.GetComponent<Stats>().barrier = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Stats>().barrier = false;
        }
    }
}
