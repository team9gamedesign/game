using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float speed = 0.05f;
    public int axis = 0;

    // Update is called once per frame
    void Update()
    {
        //Rotate on the x-axis
        if(axis == 0)
        {
            transform.Rotate(speed, 0, 0);
        }
        //Rotate on the y-axis
        else if(axis == 1)
        {
            transform.Rotate(0, speed, 0);
        }
        //Rotate on the z-axis
        else
        {
            transform.Rotate(0, 0, speed);
        }

    }
}
