using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using UnityEngine.SocialPlatforms.Impl;

public class Health : MonoBehaviour
{
    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;
    private Camera mainCamera;
    private GameOver gameOver;
    public string healthKey = "health";

    void Start()
    {
        progressBar.maxValue = 3;
        progressBar.value = 3;
        if (PlayerPrefs.GetInt("isLoad") == 1)
        {
            loadHealth();
        }
        gameOver = FindObjectOfType<GameOver>();
    }

    void Update()
    {
        mainCamera = Camera.main;
        Vector3 bulletViewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (bulletViewportPosition.x < 0 || bulletViewportPosition.x > 1 ||
            bulletViewportPosition.y < 0 || bulletViewportPosition.y > 1)
        {
            progressBar.value = -1;
            if (progressBar.value < 1)
            {
               // Time.timeScale = 0; 
                gameOver.ShowGameOverUI();
            }
        }
    }

    public void loadHealth()
    {
        progressBar.value = PlayerPrefs.GetInt(healthKey, 0);
        if (progressBar.value != 0)
        {
            Update();
        }
    }

    public float getHealth()
    {
        return progressBar.value;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Orange")
        {
            GetDamage(1);
        }

        if (other.tag == "Green")
        {
            GetDamage(1);
        }
        /*if (other.tag == "Spikes")
        {
            GetDamage(1);
        }*/
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Orange"))
        {
            GetDamage(1);
        }

        if (other.gameObject.CompareTag("Green"))
        {
            GetDamage(1);
        }
        if (other.gameObject.CompareTag("Fly"))
        {
            GetDamage(1);
        }
    }
    public void GetDamage(int damage)
    {
        progressBar.value -= damage;

        if (progressBar.value < 1)
        {
            Time.timeScale = 0; 
            gameOver.ShowGameOverUI();
        }
    }
}
