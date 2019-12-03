using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SewerGlobalVars : MonoBehaviour
{
    int NumberOfValvs;
    public GameObject sewerWater;
    public GameObject particleWater;
    public GameObject blockage;
    public GameObject textBox;
    public Text infoText;
    
    // Start is called before the first frame update
    void Start()
    {
        NumberOfValvs = 3;
        textBox.SetActive(false);
    }

    public void turnedAValv()
    {
        NumberOfValvs--;
        if(NumberOfValvs <= 0)
        {
            //Time to lower the sewer water
            Destroy(particleWater);
            Destroy(blockage);
            sewerWater.transform.position = sewerWater.transform.position + new Vector3(0, -2, 0);
        }
    }

    public void hideInfoBox()
    {
        textBox.SetActive(false);
    }

    public void valveInfo()
    {
        textBox.SetActive(true);
        infoText.text = "Press space to turn valve";
    }

    public void exitInfo()
    {
        textBox.SetActive(true);
        infoText.text = "Press space to exit";
    }
}
