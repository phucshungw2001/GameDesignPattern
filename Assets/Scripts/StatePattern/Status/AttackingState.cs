using UnityEngine;

namespace Assets.Scripts.Status
{
    public class AttackingState : BaseState
    {
        public AttackingState(PlayerController player) : base(player) { }

        public override void EnterState()
        {
            player.animator.SetBool("Attack", true);
            player.isAttacking = true;
        }

        public override void UpdateState()
        {
            float move = 1f; // Luôn di chuyển về phía trước

            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }

            if (move == 0)
            {
                player.ChangeState(new RunningState(player)); // Nếu không di chuyển, chuyển sang trạng thái chạy
            }
        }

        public override void ExitState()
        {
            player.animator.SetBool("Attack", false);
            player.isAttacking = false;
        }

        public override void Jump()
        {
            player.ChangeState(new JumpingState(player)); // Chuyển sang trạng thái nhảy
        }
    }
}