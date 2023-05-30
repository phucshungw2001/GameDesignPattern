using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlayerController;
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
                player.ChangeState(new IdleState(player));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.ChangeState(new AttackingState(player));
            }
        }

        public override void ExitState()
        {
            player.animator.SetFloat("Jump", 0);
        }
    }
}
