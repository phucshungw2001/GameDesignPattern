using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;
    void Start()
    {
        progressBar.maxValue = 5;
        progressBar.value = 5;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Orange")
        {
            Debug.Log("Orange");
            GetDamage(1);
        }

        if (other.tag == "Green")
        {
            Debug.Log("Green");
            GetDamage(1);
        }
    }

    public void GetDamage(int damage)
    {
        progressBar.value -= damage;
    }
}
