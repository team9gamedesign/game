using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnValve : MonoBehaviour
{
    public Camera camera;
    bool turned = false;
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            camera.GetComponent<SewerGlobalVars>().valveInfo();
            if (Input.GetKeyDown("space"))
            {
                if(!turned)
                {
                    if(camera != null)
                    {
                        camera.GetComponent<SewerGlobalVars>().turnedAValv();
                    }
                    GetComponent<Animation>().Play();
                    turned = true;
                }
                print("You turned the valve");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            camera.GetComponent<SewerGlobalVars>().hideInfoBox();
        }
    }
}
