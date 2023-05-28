using System;
using UnityEngine;

public class AttackAnimation : StateMachineBehaviour
{
  public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
    PlayerController playerController = animator.GetComponentInParent<PlayerController>();
        Debug.Log(playerController.isAttacking);
}
}
