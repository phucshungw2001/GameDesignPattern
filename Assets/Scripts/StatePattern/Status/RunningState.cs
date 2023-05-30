using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlayerController;
using UnityEngine;

namespace Assets.Scripts.Status
{
    public class RunningState : BaseState
    {
        public RunningState(PlayerController player) : base(player) { }

        public override void EnterState()
        {
            player.animator.SetFloat("Run", Mathf.Abs(Input.GetAxis("Horizontal")));
        }

        public override void UpdateState()
        {
            float move = Input.GetAxis("Horizontal");

            if (Mathf.Abs(move) == 0)
            {
                player.ChangeState(new IdleState(player));
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                player.ChangeState(new JumpingState(player));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.ChangeState(new AttackingState(player));
            }
        }
    }
}
