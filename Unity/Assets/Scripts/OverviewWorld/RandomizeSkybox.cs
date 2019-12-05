using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeSkybox : MonoBehaviour
{
    public Material skybox1;
    public Material skybox2;
    public Material skybox3;
    public Material skybox4;

    public Light mainLight;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, 4);
        if (rand == 0)
        {
            RenderSettings.skybox = skybox1;
        }
        else if (rand == 1)
        {
            RenderSettings.skybox = skybox2;
        }
        else if (rand == 2)
        {
            RenderSettings.skybox = skybox3;
            mainLight.transform.localEulerAngles = new Vector3(50, 254, 0);
            mainLight.transform.position = new Vector3(36, 22, 0);
        }
        else
            RenderSettings.skybox = skybox4;
    }
}
