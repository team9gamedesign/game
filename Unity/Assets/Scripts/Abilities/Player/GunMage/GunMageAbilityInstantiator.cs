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

    public void InstantiateBarrier()
    {
        Instantiate(barrier, transform.position, Quaternion.identity);
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
                hit.collider.gameObject.GetComponent<Stats>().ChangeHealth(-shootDamage);
                GetComponent<Stats>().ChangeHeat(shootHeat);
            }
            shotLine.SetPosition(1, hit.point);
        } else
        {
            shotLine.SetPosition(1, rayOrigin + transform.forward * shootRange);
        }

        
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
