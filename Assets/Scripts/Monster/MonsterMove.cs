using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class MonsterMove : MonoBehaviour
{
    public float moveSpeed = 0.4f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    float direction;
    private SpriteRenderer sprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = 1f;
    }
    void Update()
    {
        moveDirection = new Vector2(direction, 0f).normalized;
    }
    void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Direction"))
        {
            direction = -direction;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
/*    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }*/
}
