using Assets.Scripts.Status;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    public float jump;

    public bool isLand = false;
    public bool isAttacking = false;

    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public SpriteRenderer sprite;

    private BaseState currentState;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        currentState = new RunningState(this); // Bắt đầu với trạng thái Running
        currentState.EnterState();
    }

    private void FixedUpdate()
    {
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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Attack();
        }
    }

    private void Jump()
    {
        currentState.Jump(); // Gọi hàm nhảy từ trạng thái hiện tại
    }

    private void Attack()
    {
        currentState.Attack(); // Gọi hàm tấn công từ trạng thái hiện tại
    }

    public void ChangeState(BaseState newState)
    {
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

    public Vector2 GetPosition()
    {
        return transform.position;
    }
}