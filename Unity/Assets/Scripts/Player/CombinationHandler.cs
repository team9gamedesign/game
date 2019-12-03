using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationHandler : MonoBehaviour
{
    [HideInInspector]
    public GameObject QKeyCombination;
    [HideInInspector]
    public GameObject EKeyCombination;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && QKeyCombination != null)
        {
            GameObject combination = Instantiate(QKeyCombination, transform.position, Quaternion.identity);
            combination.GetComponent<Ability>().user = gameObject;
            QKeyCombination = null;
        }
        if (Input.GetKey(KeyCode.E) && EKeyCombination != null)
        {
            GameObject combination = Instantiate(EKeyCombination, transform.position, Quaternion.identity);
            combination.GetComponent<Ability>().user = gameObject;
            EKeyCombination = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Combination"))
        {
            if(QKeyCombination == null)
            {
                QKeyCombination = other.GetComponent<Combination>().combination;
                Destroy(other.gameObject);
            } else if(EKeyCombination == null)
            {
                EKeyCombination = other.GetComponent<Combination>().combination;
                Destroy(other.gameObject);
            }
        }
    }
}
