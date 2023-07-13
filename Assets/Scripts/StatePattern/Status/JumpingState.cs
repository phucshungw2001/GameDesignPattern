using UnityEngine;

namespace Assets.Scripts.Status
{
    public class JumpingState : BaseState
    {
        public JumpingState(PlayerController player) : base(player) { }

        public override void EnterState()
        {
            player.animator.SetFloat("Jump", 1);
            player.isLand = false;
            player.rigidbody2D.velocity = new Vector2(player.rigidbody2D.velocity.x, player.jump);
        }

        public override void UpdateState()
        {
            if (player.isLand)
            {
                player.ChangeState(new RunningState(player)); // Nếu chạm đất, chuyển sang trạng thái chạy
            }

            if (Input.GetMouseButtonDown(1))
            {
                Attack();
            }
        }

        public override void ExitState()
        {
            player.animator.SetFloat("Jump", 0);
        }

        public override void Attack()
        {
            player.ChangeState(new AttackingState(player)); // Chuyển sang trạng thái tấn công
        }
    }
}
