using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyShot : MonoBehaviour
{
    private GameObject player;
    public float speed = 20f;
    public float damage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player;
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            player.GetComponent<Stats>().ChangeHealth(-damage);
            Destroy(gameObject);
        }
    }
}
