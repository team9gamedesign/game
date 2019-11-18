using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInstantiator : MonoBehaviour
{
    public GameObject earthShatter;
    public GameObject pommelHitbox;
    public GameObject bullRushDust;

    public void InstantiateEarthShatter()
    {
        Instantiate(earthShatter, transform.position, transform.rotation);
        Follow cameraFollow = Camera.main.GetComponent<Follow>();
        cameraFollow.shake = true;
        cameraFollow.shakeTimer = 0.3f;
    }

    public void InstantiatePommelHitbox()
    {
        Instantiate(pommelHitbox, transform.position + transform.forward, transform.rotation);
    }

    public void StartBullRush()
    {
        Stats stats = GetComponent<Stats>();
        stats.bullRush = true;
        stats.bullRushTimer = 0.3f;
        Instantiate(bullRushDust, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
    }
}
