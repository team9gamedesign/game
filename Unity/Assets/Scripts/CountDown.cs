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

    public List<Slider> CDSliders;

    float CoolDown = 2; //TODO: Reference properly

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> abilities = GameObject.FindWithTag("Player").GetComponent<Abilities>().abilities;
        List<float> cooldowns = new List<float>();
        for(int i = 0; i < abilities.Count; ++i)
        {
            Ability abilityComponent = abilities[i].GetComponent<Ability>();
            if(abilityComponent.usesGlobalCD)
            {
                cooldowns.Add(GameObject.FindWithTag("Player").GetComponent<Stats>().globalCDValue);
                cooldowns[i] = Mathf.Max(cooldowns[i], abilityComponent.cooldown);
            } else
            {
                cooldowns.Add(abilityComponent.cooldown);
            }
        }
        CDSlider1.maxValue = CoolDown;
        CDSlider2.maxValue = CoolDown;
        CDSlider3.maxValue = CoolDown;
        CDSlider4.maxValue = CoolDown;
        CDSliderLM.maxValue = cooldowns[0];
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
