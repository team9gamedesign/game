using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Slider CDSlider1;
    public Slider CDSlider2;
    public Slider CDSlider3;
    public Slider CDSlider4;
    public Slider CDSliderLM;
    public Slider CDSliderRM;

    float CoolDown = 2; //TODO: Reference properly

    // Start is called before the first frame update
    void Start()
    {
        CDSlider1.maxValue = CoolDown; // GetComponent<PlayerAttackHandler>().GlobalCDValue;
        CDSlider2.maxValue = CoolDown;
        CDSlider3.maxValue = CoolDown;
        CDSlider4.maxValue = CoolDown;
        CDSliderLM.maxValue = CoolDown;
        CDSliderRM.maxValue = CoolDown;

        CDSlider1.value = 0;
        CDSlider2.value = CoolDown;
        CDSlider3.value = CoolDown;
        CDSlider4.value = CoolDown;
        CDSliderLM.value = 0;
        CDSliderRM.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse0 = left mouse button
        //Mouse1 = right mouse button
        //Alpha1-4 or Keypad1-4

        if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) && CDSlider1.value == 0)
        {
            CDSlider1.value = CoolDown;
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) && CDSlider2.value == 0)
        {
            CDSlider2.value = CoolDown;
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) && CDSlider3.value == 0)
        {
            CDSlider3.value = CoolDown;
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) && CDSlider4.value == 0)
        {
            CDSlider4.value = CoolDown;
        }
        else if ((Input.GetKeyDown(KeyCode.Mouse0) && CDSliderLM.value == 0))
        {
            CDSliderLM.value = CoolDown;
        }
        else if ((Input.GetKeyDown(KeyCode.Mouse1) && CDSliderRM.value == 0))
        {
            CDSliderRM.value = CoolDown;
        }

        if (CDSlider1.value > 0)
        {
            CDSlider1.value -= Time.deltaTime;
        }
        /*if (CDSlider2.value > 0)
        {
            CDSlider2.value -= Time.deltaTime;
        }
        if (CDSlider3.value > 0)
        {
            CDSlider3.value -= Time.deltaTime;
        }
        if (CDSlider4.value > 0)
        {
            CDSlider4.value -= Time.deltaTime;
        }*/
        if (CDSliderLM.value > 0)
        {
            CDSliderLM.value -= Time.deltaTime;
        }
        if (CDSliderRM.value > 0)
        {
            CDSliderRM.value -= Time.deltaTime;
        }
    }
}
