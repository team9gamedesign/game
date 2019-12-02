using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    //Insert the CoolDown timers
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

    private Stats stats;
    public List<bool> requiresLevel;
    public List<int> levelRequirements;

    // Start is called before the first frame update
    void Start()
    {
        stats = PlayerManager.instance.player.GetComponent<Stats>();
        List<GameObject> abilities = PlayerManager.instance.player.GetComponent<Abilities>().abilities;
        List<float> cooldownsMax = new List<float>();
        usesGlobalCD = new List<bool>();
        requiresLevel = new List<bool>();
        levelRequirements = new List<int>();

        for(int i = 0; i < abilities.Count; ++i)
        {
            //Retrieve for all abilities the max cooldown value, put them in list cooldownsMax
            Ability abilityComponent = abilities[i].GetComponent<Ability>();

            requiresLevel.Add(abilityComponent.requiresLevel);
            levelRequirements.Add(abilityComponent.levelRequirement);

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

        //Set cooldown timer max values according to list cooldownsMax 
        CDLM_max = cooldownsMax[0];
        CDRM_max = cooldownsMax[1];
        CD1_max = cooldownsMax[2];
        CD2_max = cooldownsMax[3];
        CD3_max = cooldownsMax[4];
        CD4_max = cooldownsMax[5];

        //Initially put all cooldown timers on 0
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
        //Acquire list of currentCooldowns
        currentCooldowns = PlayerManager.instance.player.GetComponent<Abilities>().abilityCooldowns;
        float GlobalCD = PlayerManager.instance.player.GetComponent<AttackHandler>().globalCD;
    
        //Update, for each cooldowntimer, the current cooldown value based on local and global cooldowns
        //Left mouse button
        CDLM_current = currentCooldowns[0];

        if (usesGlobalCD[0] && CDLM_current < GlobalCD)
        {
            CDLM_current = GlobalCD;
        }

        if(requiresLevel[0] && stats.level < levelRequirements[0])
        {
            CDLM_current = CDLM_max;
        }

        //Right mouse button
        CDRM_current = currentCooldowns[1];

        if (usesGlobalCD[1] && CDRM_current < GlobalCD)
        {
            CDRM_current = GlobalCD;
        }

        if (requiresLevel[1] && stats.level < levelRequirements[1])
        {
            CDRM_current = CDRM_max;
        }

        //1 button
        CD1_current = currentCooldowns[2];

        if (usesGlobalCD[2] && CD1_current < GlobalCD)
        {
            CD1_current = GlobalCD;
        }

        if (requiresLevel[2] && stats.level < levelRequirements[2])
        {
            CD1_current = CD1_max;
        }

        //2 button
        CD2_current = currentCooldowns[3];

        if (usesGlobalCD[3] && CD2_current < GlobalCD)
        {
            CD2_current = GlobalCD;
        }

        if (requiresLevel[3] && stats.level < levelRequirements[3])
        {
            CD2_current = CD2_max;
        }

        //3 button
        CD3_current = currentCooldowns[4];

        if (usesGlobalCD[4] && CD3_current < GlobalCD)
        {
            CD3_current = GlobalCD;
        }

        if (requiresLevel[4] && stats.level < levelRequirements[4])
        {
            CD3_current = CD3_max;
        }

        //4 button
        CD4_current = currentCooldowns[5];

        if (usesGlobalCD[5] && CD4_current < GlobalCD)
        {
            CD4_current = GlobalCD;
        }

        if (requiresLevel[5] && stats.level < levelRequirements[5])
        {
            CD4_current = CD4_max;
        }

        //Fill the cooldown timers accordingly
        CDLM.fillAmount = CDLM_current/CDLM_max;
        CDRM.fillAmount = CDRM_current/CDRM_max;
        CD1.fillAmount = CD1_current/CD1_max;
        CD2.fillAmount = CD2_current/CD2_max;
        CD3.fillAmount = CD3_current/CD3_max;
        CD4.fillAmount = CD4_current/CD4_max;
    }
}
