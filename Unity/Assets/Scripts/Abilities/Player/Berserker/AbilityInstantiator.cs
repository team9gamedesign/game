using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInstantiator : MonoBehaviour
{
    public GameObject earthShatter;
    public GameObject pommelHitbox;
    public GameObject bullRushDust;
    public GameObject kickHitbox;

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
        Animator animator = GetComponent<Animator>();
        animator.SetInteger("BullRush", animator.GetInteger("BullRush") - 1);
        Instantiate(bullRushDust, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
    }

    public void InstantiateKickHitbox()
    {
        float zDistance = kickHitbox.GetComponent<BoxCollider>().size.z;
        Instantiate(kickHitbox, transform.position + zDistance/2 * transform.forward, transform.rotation);
    }
}
