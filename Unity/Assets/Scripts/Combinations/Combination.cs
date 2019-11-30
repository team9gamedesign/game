using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{
    public GameObject combination;

    private float angle;

    void Start()
    {
        angle = transform.eulerAngles.z;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z));
        angle += Time.deltaTime * 90;
    }
}
