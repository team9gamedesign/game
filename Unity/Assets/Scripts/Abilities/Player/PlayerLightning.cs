using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightning : StateMachineBehaviour
{
    public GameObject lightningBolt;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject player = animator.gameObject;
        animator.SetBool("Lightning", false);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemies.Length > 0)
        {
            GameObject closestEnemy = null;
            float closestDistance = Mathf.Infinity;
            foreach (GameObject enemy in enemies)
            {
                float enemyDistance = Vector3.Distance(player.transform.position, enemy.transform.position);
                if (enemyDistance < closestDistance)
                {
                    closestDistance = enemyDistance;
                    closestEnemy = enemy;
                }
            }
            if(closestEnemy != null)
            {
                GameObject lightning = Instantiate(lightningBolt, player.transform.position, Quaternion.identity);
                lightning.GetComponent<LightningBolt>().enemy = closestEnemy;
            }
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
