using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyShot : MonoBehaviour
{
    [HideInInspector]
    public GameObject player;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, 10f);
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
            player.GetComponent<Stats>().ChangeHealth(-1);
            Destroy(gameObject);
        }
    }
}
