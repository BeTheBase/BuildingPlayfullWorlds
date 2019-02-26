using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    public float MaxRange = 5;
    private PatrolSpots patrol;
    public float Speed = 10;
    private int randomSpot;
    private Transform playerPos;
    private NavMeshAgent agent;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patrol = GameObject.FindGameObjectWithTag("PatrolSpots").GetComponent<PatrolSpots>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        randomSpot = Random.Range(0, patrol.patrolPoints.Length);
        agent = animator.GetComponent<NavMeshAgent>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var newPointDistance = patrol.patrolPoints[randomSpot].position - animator.transform.position;
        var step = Speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(animator.transform.forward, newPointDistance, step, 0.0f);
        var playerDistance = playerPos.position - animator.transform.position;

        if (Vector3.Distance(animator.transform.position, patrol.patrolPoints[randomSpot].position) > 0.2f)
        {
            //animator.transform.position = Vector3.MoveTowards(animator.transform.position, patrol.patrolPoints[randomSpot].position, step);
            //animator.transform.rotation = Quaternion.LookRotation(newDir);
            agent.SetDestination(patrol.patrolPoints[randomSpot].position);
        }
        else
        {
            randomSpot = Random.Range(0, patrol.patrolPoints.Length);
        }

        if (playerDistance.sqrMagnitude < MaxRange * MaxRange)
        {
            animator.SetBool("isPatrolling", false);
            animator.SetBool("isFollowing", true);
        }

    }


    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
