using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlashHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Stats>().ChangeHealth(-5);
        }
    }
}