using UnityEngine;

public class RangedEnemyAttackHandler : AttackHandler
{
    GameObject player;
    public bool throwBombAbility = false;
    public float shootDistance = 15;
    new void Start()
    {
        base.Start();
        player = PlayerManager.instance.player;
    }

    void Update()
    {
        globalCD = Mathf.Max(0, globalCD - Time.deltaTime);
        if (globalCD <= 0 && Vector3.Distance(transform.position, player.transform.position) <= shootDistance)
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
