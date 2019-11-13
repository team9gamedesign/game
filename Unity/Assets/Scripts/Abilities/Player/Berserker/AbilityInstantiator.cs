using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInstantiator : MonoBehaviour
{
    public GameObject earthShatter;
    public GameObject pommelHitbox;

    public void InstantiateEarthShatter()
    {
        Instantiate(earthShatter, transform.position, transform.rotation);
        Follow cameraFollow = Camera.main.GetComponent<Follow>();
        cameraFollow.shake = true;
        cameraFollow.shakeTimer = 0.2f;
    }

    public void InstantiatePommelHitbox()
    {
        Instantiate(pommelHitbox, transform.position + transform.forward, transform.rotation);
    }
}
