using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShatter : MonoBehaviour
{
    public GameObject earthShatter;

    public void InstantiateEarthShatter()
    {
        Instantiate(earthShatter, transform.position, transform.rotation);
        Follow cameraFollow = Camera.main.GetComponent<Follow>();
        cameraFollow.shake = true;
        cameraFollow.shakeTimer = 0.2f;
    }
}
