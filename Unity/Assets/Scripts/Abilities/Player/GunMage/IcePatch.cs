using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePatch : MonoBehaviour
{
    public float aliveTime;


    private Vector3 maxSize;

    // Start is called before the first frame update
    void Start()
    {
        maxSize = transform.localScale;
        transform.localScale = new Vector3(0.1f, transform.localScale.y, 0.1f);
        Destroy(gameObject, aliveTime);
    }

    void Update()
    {
        if(Vector3.Distance(maxSize, transform.localScale) < 0.1f)
        {
            transform.localScale = maxSize;
        } else
        {
            transform.localScale = new Vector3(
                Mathf.Lerp(transform.localScale.x, maxSize.x, 0.25f),
                transform.localScale.y,
                Mathf.Lerp(transform.localScale.z, maxSize.z, 0.25f)
            );
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Stats>().speed /= 2;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Stats>().ChangeHealth(-Time.deltaTime);
        }
    }
}
