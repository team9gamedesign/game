using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttack : StateMachineBehaviour
{
    private GameObject player;
    public float dealDamageAfterSeconds = 1f; //TODO: Really shitty way of fixing the issue of delayed damage dealing, but ¯\_(ツ)_/¯
    private float timer = 0;
    private bool dealtDamage = false;
    public float damage = 1f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dealtDamage = false;
        timer = 0;
        player = PlayerManager.instance.player;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(dealtDamage)
            return;

        timer += Time.deltaTime;
        if (timer > dealDamageAfterSeconds)
        {
            player.GetComponent<Stats>().ChangeHealth(-damage);
            dealtDamage = true;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attack",false);
    }

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
