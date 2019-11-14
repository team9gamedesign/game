using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    private Transform player;
    private float playerRadius;
    public float aggroRange = 10f;    
    public bool shouldPatrol = true;
    public Vector2 patrolDistance = new Vector2(5,5);
    public float timeBetweenPatrols = 5f;
    private float timeBetweenPatrolsTimer = 0;
    private bool hasAggroed = false;

    void Start()
    {
        player = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim =  GetComponent<Animator>();
        playerRadius = player.GetComponent<CharacterController>().radius;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(anim)
        {
            anim.SetFloat("Speed", agent.desiredVelocity.magnitude);
        }
        
        if(hasAggroed)
        {
            agent.SetDestination(player.position - (player.position - transform.position).normalized * (playerRadius + agent.radius));
            Rotation();
        }
        else
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance <= aggroRange)
            {
                hasAggroed = true;
                agent.SetDestination(player.position - (player.position - transform.position).normalized * (playerRadius + agent.radius));
            }
            else if(shouldPatrol)
            {
                PatrolRandomly();
            }
        }
    }

    void Rotation()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void PatrolRandomly()
    {
        if(!agent.hasPath)
        {
            timeBetweenPatrolsTimer -= Time.deltaTime;
            if(timeBetweenPatrolsTimer < 0)
            {
                timeBetweenPatrolsTimer = timeBetweenPatrols;
                agent.SetDestination(transform.position + new Vector3(Random.Range(-patrolDistance.x,patrolDistance.x), 0, Random.Range(-patrolDistance.y,patrolDistance.y)));
            }
        }
    }
}
