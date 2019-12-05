using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInstantiator : MonoBehaviour
{
    public GameObject earthShatter;
    public GameObject pommelHitbox;
    public GameObject bullRushDust;
    public GameObject kickHitbox;

    private Stats stats;

    void Start()
    {
        stats = GetComponent<Stats>();
    }

    public void InstantiateEarthShatter()
    {
        GameObject earthShatterObject = Instantiate(earthShatter, transform.position, transform.rotation);
        earthShatterObject.GetComponent<EarthShatterDamage>().damage *= stats.damageFactor;
        Follow cameraFollow = Camera.main.GetComponent<Follow>();
        cameraFollow.shake = true;
        Animator animator = GetComponent<Animator>();
        animator.SetInteger("EarthShatter", animator.GetInteger("EarthShatter") - 1);
        cameraFollow.shakeTimer = 0.3f;
    }

    public void InstantiatePommelHitbox()
    {
        GameObject pommelHitboxObject = Instantiate(pommelHitbox, transform.position + transform.forward, transform.rotation);
        pommelHitboxObject.GetComponent<PlayerAbilityHitbox>().damage *= stats.damageFactor;
        Animator animator = GetComponent<Animator>();
        animator.SetInteger("Pommel", animator.GetInteger("Pommel") - 1);
    }

    public void StartBullRush()
    {
        stats.bullRush = true;
        stats.bullRushTimer = 0.3f;
        Animator animator = GetComponent<Animator>();
        animator.SetInteger("BullRush", animator.GetInteger("BullRush") - 1);
        Instantiate(bullRushDust, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
    }

    public void InstantiateKickHitbox()
    {
        float zDistance = kickHitbox.GetComponent<BoxCollider>().size.z;
        GameObject kickHitboxObject = Instantiate(kickHitbox, transform.position + zDistance/2 * transform.forward, transform.rotation);
        kickHitboxObject.GetComponent<PlayerAbilityHitbox>().damage *= stats.damageFactor;
        Animator animator = GetComponent<Animator>();
        animator.SetInteger("Kick", animator.GetInteger("Kick") - 1);
    }
}
