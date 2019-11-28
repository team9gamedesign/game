using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Image CDLM; 
    public Image CDRM;
    public Image CD1;
    public Image CD2;
    public Image CD3;
    public Image CD4;
        
    float CDLM_max;
    float CDRM_max;
    float CD1_max;
    float CD2_max;
    float CD3_max;
    float CD4_max;

    float CDLM_current;
    float CDRM_current;
    float CD1_current;
    float CD2_current;
    float CD3_current;
    float CD4_current;

    public List<float> currentCooldowns;
    public List<bool> usesGlobalCD;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> abilities = PlayerManager.instance.player.GetComponent<Abilities>().abilities;
        List<float> cooldownsMax = new List<float>();
        usesGlobalCD = new List<bool>();

        for(int i = 0; i < abilities.Count; ++i)
        {
            Ability abilityComponent = abilities[i].GetComponent<Ability>();
            if(abilityComponent.usesGlobalCD)
            {
                cooldownsMax.Add(PlayerManager.instance.player.GetComponent<Stats>().globalCDValue);
                cooldownsMax[i] = Mathf.Max(cooldownsMax[i], abilityComponent.cooldown);
                usesGlobalCD.Add(true);
            } else
            {
                cooldownsMax.Add(abilityComponent.cooldown);
                usesGlobalCD.Add(false);
            }
        }

        CDLM_max = cooldownsMax[0];
        CDRM_max = cooldownsMax[1];
        CD1_max = cooldownsMax[2];
        CD2_max = cooldownsMax[3];
        CD3_max = cooldownsMax[4];
        CD4_max = cooldownsMax[5];

        CDLM.fillAmount = 0;
        CDRM.fillAmount = 0;
        CD1.fillAmount = 0;
        CD2.fillAmount = 0;
        CD3.fillAmount = 0;
        CD4.fillAmount = 0;
   
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldowns = PlayerManager.instance.player.GetComponent<Abilities>().abilityCooldowns;
        float GlobalCD = PlayerManager.instance.player.GetComponent<AttackHandler>().globalCD;

        
        CDLM_current = currentCooldowns[0];

        if (usesGlobalCD[0] && CDLM_current < GlobalCD)
        {
            CDLM_current = GlobalCD;
        }

        CDRM_current = currentCooldowns[1];

        if (usesGlobalCD[1] && CDRM_current < GlobalCD)
        {
            CDRM_current = GlobalCD;
        }

        CD1_current = currentCooldowns[2];

        if (usesGlobalCD[2] && CD1_current < GlobalCD)
        {
            CD1_current = GlobalCD;
        }

        CD2_current = currentCooldowns[3];

        if (usesGlobalCD[3] && CD2_current < GlobalCD)
        {
            CD2_current = GlobalCD;
        }

        CD3_current = currentCooldowns[4];

        if (usesGlobalCD[4] && CD3_current < GlobalCD)
        {
            CD3_current = GlobalCD;
        }

        CD4_current = currentCooldowns[5];

        if (usesGlobalCD[5] && CD4_current < GlobalCD)
        {
            CD4_current = GlobalCD;
        }

        CDLM.fillAmount = CDLM_current/CDLM_max;
        CDRM.fillAmount = CDRM_current/CDRM_max;
        CD1.fillAmount = CD1_current/CD1_max;
        CD2.fillAmount = CD2_current/CD2_max;
        CD3.fillAmount = CD3_current/CD3_max;
        CD4.fillAmount = CD4_current/CD4_max;
    }
}
