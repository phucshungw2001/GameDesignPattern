using Assets.Scripts.Status;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 3f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer trailRenderer; 
    Health health;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        health = FindObjectOfType<Health>();

        currentState = new RunningState(this); // Bắt đầu với trạng thái Running
        currentState.EnterState();
    }

    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
        currentState.UpdateState();

        rigidbody2D.velocity = new Vector2((float)0.015 * speed, rigidbody2D.velocity.y);
    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Attack();
        }
        if(Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
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

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float orginalGravity = rigidbody2D.gravityScale;
        rigidbody2D.gravityScale = 0f;
        rigidbody2D.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        rigidbody2D.gravityScale = orginalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DeadLine")
        {
            health.GetDamage(5);
            SceneManager.LoadScene(1);
        }
    }
}