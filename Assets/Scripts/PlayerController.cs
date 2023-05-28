using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jump;

    public bool isLand = false;
    public bool isAttacking = false;

    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public SpriteRenderer sprite;

    private BaseState currentState;

    private void Start()
    {
        // Khởi tạo các biến và gán trạng thái ban đầu là IdleState
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        currentState = new IdleState(this);
        currentState.EnterState();
    }

    private void FixedUpdate()
    {
        // Gọi phương thức UpdateState của trạng thái hiện tại để xử lý logic
        currentState.UpdateState();

        float move = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(move * speed, rigidbody2D.velocity.y);

        if (move > 0)
        {
            sprite.flipX = false;
        }
        if (move < 0)
        {
            sprite.flipX = true;
        }
    }

    public void ChangeState(BaseState newState)
    {
        // Thoát khỏi trạng thái hiện tại, chuyển sang trạng thái mới và nhập trạng thái mới
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            isLand = true;
        }
    }
    public void FinishAttack()
    {
        animator.SetBool("Attack", false);
        isAttacking = false;
    }

    public abstract class BaseState
    {
        protected PlayerController player;

        public BaseState(PlayerController player)
        {
            this.player = player;
        }

        public virtual void EnterState() { }
        public virtual void UpdateState() { }
        public virtual void ExitState() { }
    }

    public class IdleState : BaseState
    {
        public IdleState(PlayerController player) : base(player) { }

        public override void EnterState()
        {
            player.animator.SetFloat("Run", 0);
        }

        public override void UpdateState()
        {
            float move = Input.GetAxis("Horizontal");

            if (Mathf.Abs(move) > 0)
            {
                player.ChangeState(new RunningState(player));
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
