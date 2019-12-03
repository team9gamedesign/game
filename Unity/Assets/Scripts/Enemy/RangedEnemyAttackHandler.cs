using UnityEngine;

public class RangedEnemyAttackHandler : AttackHandler
{
    GameObject player;
    public bool throwBombAbility = false;
    new void Start()
    {
        base.Start();
        player = PlayerManager.instance.player;
    }

    void Update()
    {
        globalCD = Mathf.Max(0, globalCD - Time.deltaTime);
        if (globalCD <= 0 && Vector3.Distance(transform.position, player.transform.position) <= 15)
        {
            if(throwBombAbility)
            {
                UseAbility(1);
            }
            else
            {
                UseAbility(0);
            }
            
        }
    }
}
