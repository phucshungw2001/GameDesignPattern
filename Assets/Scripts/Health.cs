using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;
    private Camera mainCamera;
    private GameOver gameOver;

    void Start()
    {
        progressBar.maxValue = 3;
        progressBar.value = 3;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Orange" || other.tag == "Green" || other.tag == "Spikes")
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
