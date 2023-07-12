using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncerementScore : MonoBehaviour
{
    Score score;
    bool check;
    void Start()
    {
        score = FindObjectOfType<Score>();
        check = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (check)
            {
                score.incrementScore();
                check = false;
            }
        }
    }
}
