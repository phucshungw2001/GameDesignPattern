using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTrap : MonoBehaviour
{
    public int random;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            random = Random.Range(0, 3);
        }
    }
}
