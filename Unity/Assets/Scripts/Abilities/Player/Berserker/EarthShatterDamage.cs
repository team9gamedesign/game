using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShatterDamage : MonoBehaviour
{
    public float damage = 1;
    List<Collider> enemiesHit;
    // Start is called before the first frame update
    void Start()
    {
        enemiesHit = new List<Collider>();
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            if(!enemiesHit.Contains(other))
            {
                enemiesHit.Add(other);
                other.GetComponent<Stats>().ChangeHealth(-damage);
            }
        }
    }
}
