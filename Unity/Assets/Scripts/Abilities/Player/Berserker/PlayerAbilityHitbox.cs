using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityHitbox : MonoBehaviour
{
    public float damage;
    public GameObject sound;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Stats>().ChangeHealth(-damage);
            GameObject soundObject = Instantiate(sound);
            Destroy(soundObject, 5f);
        }
    }
}