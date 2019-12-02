using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMageAbilityInstantiator : MonoBehaviour
{
    public GameObject gunEnd;
    public float shootRange;
    public float shootDamage;
    public int shootHeat;
    public GameObject barrier;
    public GameObject icePatch;
    public GameObject fireBall;

    private Stats stats;

    void Start()
    {
        stats = GetComponent<Stats>();
    }

    public void InstantiateBarrier()
    {
        GameObject barrierObject = Instantiate(barrier, transform.position, Quaternion.identity);
        barrierObject.GetComponent<Barrier>().aliveTime *= stats.doubleUpFactor;
        stats.doubleUpFactor = 1;
    }

    public void InstantiateIcePatch()
    {
        Vector3 transformGround = new Vector3(
            transform.position.x,
            0,
            transform.position.z
        );
        GameObject icePatchObject = Instantiate(icePatch, transformGround, Quaternion.identity);
        icePatchObject.GetComponent<IcePatch>().damageFactor = stats.damageFactor;
        icePatchObject.GetComponent<IcePatch>().maxSize *= stats.doubleUpFactor;
        stats.doubleUpFactor = 1;
    }

    public void InstantiateShot()
    {
        LineRenderer shotLine = gunEnd.GetComponent<LineRenderer>();

        StartCoroutine(RenderShot());

        Vector3 rayOrigin = gunEnd.transform.position;

        shotLine.SetPosition(0, rayOrigin);

        if (Physics.Raycast(rayOrigin, transform.forward, out RaycastHit hit, shootRange))
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<Stats>().ChangeHealth(-shootDamage * stats.damageFactor);
                GetComponent<Stats>().ChangeHeat(shootHeat);
            }
            shotLine.SetPosition(1, hit.point);
        } else
        {
            shotLine.SetPosition(1, rayOrigin + transform.forward * shootRange);
        }

        GetComponent<AudioSource>().Play();
    }

    public void InstantiateLastShot()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetInteger("Shoot", animator.GetInteger("Shoot") - 1);
        InstantiateShot();
    }

    public void InstantiateFireBall()
    {
        GameObject fireBallObject = Instantiate(fireBall, gunEnd.transform.position, transform.rotation);
        fireBallObject.GetComponent<FireBall>().damage *= stats.damageFactor;
        Animator animator = GetComponent<Animator>();
        animator.SetInteger("FireBall", animator.GetInteger("FireBall") - 1);
    }

    private IEnumerator RenderShot()
    {
        gunEnd.GetComponent<LineRenderer>().enabled = true;
        gunEnd.GetComponent<Light>().enabled = true;

        yield return Time.deltaTime;

        gunEnd.GetComponent<LineRenderer>().enabled = false;
        gunEnd.GetComponent<Light>().enabled = false;
    }
}
