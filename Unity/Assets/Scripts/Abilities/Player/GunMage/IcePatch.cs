﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePatch : MonoBehaviour
{
    public float aliveTime;
    private float aliveTimer;

    [HideInInspector]
    public float damageFactor;

    public Vector3 maxSize;

    // Start is called before the first frame update
    void Start()
    {
        aliveTimer = aliveTime;
        transform.localScale = new Vector3(0.1f, transform.localScale.y, 0.1f);
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

        aliveTimer -= Time.deltaTime;
        if(aliveTimer <= 0)
        {
            transform.localScale = new Vector3(
                Mathf.Lerp(transform.localScale.x, 0, 0.25f),
                Mathf.Lerp(transform.localScale.y, 0, 0.25f),
                Mathf.Lerp(transform.localScale.z, 0, 0.25f)
            );

            if(aliveTimer <= -2)
            {
                Destroy(gameObject);
            }
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
            other.GetComponent<Stats>().ChangeHealth(-Time.deltaTime * damageFactor);
        }
    }
}
