using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{    
    public float aggroRange = 10f;    
    public float stopDistance = 5;
    public bool shouldPatrol = true;
    public Vector2 patrolDistance = new Vector2(5,5);
    public float timeBetweenPatrols = 5f;

    private Animator anim;
    private NavMeshAgent agent;
    private NavMeshObstacle obstacle;
    private Transform player;
    private float playerRadius;
    private float timeBetweenPatrolsTimer = 0;

    void Start()
    {
        player = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        anim =  GetComponent<Animator>();
        playerRadius = player.GetComponent<CharacterController>().radius;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {  
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance <= stopDistance)
        {
            if(agent.gameObject.activeSelf)
            {
                agent.enabled = false;
                obstacle.enabled = true;
            }
            Rotation();
        }
        else if(distance <= aggroRange)
        {
            if(obstacle.gameObject.activeSelf)
            {
                obstacle.enabled = false;
                agent.enabled = true;
            }
            if(!agent.hasPath || agent.isPathStale || (agent.hasPath && Vector3.Distance(agent.path.corners[agent.path.corners.Length - 1], player.position) > 1))
            {
                NavMeshPath path = new NavMeshPath();
                agent.CalculatePath(player.position, path);
                if(path.status == NavMeshPathStatus.PathComplete)
                {
                    agent.SetDestination(player.position);
                }
                else if(path.status == NavMeshPathStatus.PathPartial)
                {
                    agent.SetDestination(path.corners[Mathf.FloorToInt(path.corners.Length * 0.8f)]);
                } 
            }
        }
        else if(shouldPatrol)
        {
            PatrolRandomly();
        }

        if(anim)    //Push the speed to the animator
        {
            anim.SetFloat("Speed", agent.desiredVelocity.magnitude);
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
                NavMeshHit hit;
                Vector3 sampledPosition =  new Vector3(transform.position.x + Random.Range(-patrolDistance.x,patrolDistance.x), 0, transform.position.z + Random.Range(-patrolDistance.y,patrolDistance.y));
                NavMesh.SamplePosition(sampledPosition, out hit, patrolDistance.x, 1);
                agent.SetDestination(hit.position);
            }
        }
    }
}
