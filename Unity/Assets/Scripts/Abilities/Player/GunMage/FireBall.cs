using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float aliveTime;
    public float speed;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, aliveTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Stats>().ChangeHealth(-damage);
        }
    }
}
