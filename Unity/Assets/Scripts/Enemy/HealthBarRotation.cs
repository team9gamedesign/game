using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRotation : MonoBehaviour
{
    /* This script was created, because upon spawning, the healthBar is a child of the enemy meaning that if the enemy turns over the Y-axis, 
     * so does the healthBar, which is unwanted. This script ensures that for any changes in Y rotation by the enemy, the healthBar does
     * an opposite change in Y direction, enabling it to always face the camera. */

    public Transform enemy;
    public Transform healthBar;

    private Quaternion currentRotationEnemy;

    public float currentAngleY;
    public float newAngleY;
    public float diffAngleY;

    // Start is called before the first frame update
    void Start()
    {
        //Calculating Y angle of the enemy at start
        currentAngleY = enemy.transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Calculating the difference in Y angle since the last update
        newAngleY = enemy.transform.localEulerAngles.y;
        diffAngleY = newAngleY - currentAngleY;

        currentAngleY = newAngleY;

        //Rotating the healthBar in the opposite direction
        healthBar.rotation = Quaternion.Euler(0f, -diffAngleY, 0f);

    }
}
