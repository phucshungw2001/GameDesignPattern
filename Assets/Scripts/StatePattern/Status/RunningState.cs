using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlayerController;
using UnityEngine;

using UnityEngine;

namespace Assets.Scripts.Status
{
    public class RunningState : BaseState
    {
        public RunningState(PlayerController player) : base(player) { }

        public override void EnterState()
        {
            player.animator.SetFloat("Run", 1); // Đặt giá trị Run = 1 để chạy animation
        }

        public override void UpdateState()
        {
            float move = 1f; // Luôn di chuyển về phía trước

            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }

            if (Input.GetMouseButtonDown(1))
            {
                Attack();
            }

            player.rigidbody2D.velocity = new Vector2(move * 2, player.rigidbody2D.velocity.y);
        }

        public override void Jump()
        {
            player.ChangeState(new JumpingState(player)); // Chuyển sang trạng thái nhảy
        }

        public override void Attack()
        {
            player.ChangeState(new AttackingState(player)); // Chuyển sang trạng thái tấn công
        }
    }
}