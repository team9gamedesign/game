using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : StateMachineBehaviour
{
    public GameObject laserBeamPrefab;
    private GameObject laserBeam;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject gunEnd = GameObject.Find("GunEnd");

        laserBeam = Instantiate(laserBeamPrefab, gunEnd.transform.position, gunEnd.transform.rotation, gunEnd.transform);
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject player = animator.gameObject;
        player.GetComponent<Stats>().laser = false;
        Destroy(laserBeam);
    }
}
