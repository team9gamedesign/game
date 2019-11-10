using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    [HideInInspector]
    public GameObject enemy;
    [HideInInspector]
    public float damageFactor = 1;

    public GameObject lightningBolt;

    // Start is called before the first frame update
    void Start()
    {
        Transform target = gameObject.transform.Find("Target");
        target.position = enemy.transform.position;

        Destroy(gameObject, 0.25f);
    }

    private void OnDestroy()
    {
        if(damageFactor >= 5)
        {
            //Kill the enemy instantly
            enemy.GetComponent<Stats>().ChangeHealth(-enemy.GetComponent<Stats>().health);
        } else
        {
            enemy.GetComponent<Stats>().ChangeHealth(-1 * damageFactor);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length > 0)
            {
                GameObject closestEnemy = null;
                float closestDistance = 10;
                foreach (GameObject e in enemies)
                {
                    if (e == enemy)
                    {
                        continue;
                    }
                    float enemyDistance = Vector3.Distance(transform.position, e.transform.position);
                    if (enemyDistance < closestDistance)
                    {
                        closestDistance = enemyDistance;
                        closestEnemy = e;
                    }
                }
                if (closestEnemy != null)
                {
                    GameObject lightning = Instantiate(lightningBolt, enemy.transform.position, Quaternion.identity);
                    lightning.SetActive(true);
                    lightning.GetComponent<LightningBolt>().enemy = closestEnemy;
                    lightning.GetComponent<LightningBolt>().damageFactor = damageFactor + 1;
                }
            }
        }
    }
}
