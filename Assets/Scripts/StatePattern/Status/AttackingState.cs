using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            float move = Input.GetAxis("Horizontal");
            if (Mathf.Abs(move) == 0)
            {
                player.ChangeState(new IdleState(player));
            }
        }

        public override void ExitState()
        {
            player.animator.SetBool("Attack", false);
            player.isAttacking = false;
        }
    }
}
