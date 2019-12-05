using UnityEngine;

public class RangedEnemyShootAbility : MonoBehaviour
{
    void Start()
    {
        Animator enemyAnimator = GetComponent<Ability>().user.GetComponent<Animator>();
        enemyAnimator.SetBool("Shoot", true);
        enemyAnimator.SetBool("ShouldMove", false);
        Destroy(gameObject);
    }
}
