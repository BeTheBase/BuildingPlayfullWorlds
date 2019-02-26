using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehaviour : StateMachineBehaviour
{
    public float Speed;
    public float MaxRange = 5;
    public float AttackRange = 2;
    private AudioSource source;
    private Transform playerPos;

    // Start
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        source = animator.GetComponent<AudioSource>();
        source.Play();

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var step = Speed * Time.deltaTime;

        animator.transform.position = Vector3.MoveTowards(animator.transform.position, playerPos.position, step);

        var playerDistance = playerPos.position - animator.transform.position;
        Vector3 newDir = Vector3.RotateTowards(animator.transform.forward, playerDistance, step, 0.0f);
        if (playerDistance.sqrMagnitude < MaxRange * MaxRange)
        {
            //Player is within range.
            animator.SetBool("isPatrolling", false);
            animator.SetBool("isFollowing", true);
            animator.transform.rotation = Quaternion.LookRotation(newDir);
        }
        if (playerDistance.sqrMagnitude < AttackRange * AttackRange)
        {
            //Player is within Attack range
            animator.SetBool("isFollowing", true);
            animator.SetBool("isAttacking", true);
        }
        if (playerDistance.sqrMagnitude > MaxRange * MaxRange)
        {
            //Player is out of range.
            animator.SetBool("isFollowing", false);
            animator.SetBool("isPatrolling", true);
        }
    }

    //Stops
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