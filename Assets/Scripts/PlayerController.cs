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

    public int health = 5;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        currentState = new IdleState(this);
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
}
