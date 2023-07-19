using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    GameObject playerTranform;
    public float moveForce = 10f;
    private Rigidbody2D rb;
    bool checkattack;
    private void Start()
    {
        checkattack = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        playerTranform = GameObject.FindGameObjectWithTag("Player");
        if (collision.gameObject.CompareTag("Player"))
        {
            if (checkattack)
            {
                rb = GetComponent<Rigidbody2D>();
                StartCoroutine(startAttack());
                checkattack = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator startAttack()
    {
        yield return new WaitForSeconds(0.1f);
        playerTranform = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = playerTranform.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * moveForce;
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

    }
}
