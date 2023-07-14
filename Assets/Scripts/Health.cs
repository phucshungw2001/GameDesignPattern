using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;
    private Camera mainCamera;
    private GameOver gameOver;

    void Start()
    {
        progressBar.maxValue = 5;
        progressBar.value = 5;

        // Lấy reference đến component GameOver
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
            if (progressBar.value <= 0)
            {
                // Nếu máu về dưới 0, hiển thị giao diện Game Over
                gameOver.ShowGameOverUI();
            }
        }
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
        if (other.tag == "Spikes")
        {
            GetDamage(1);
        }
    }

    public void GetDamage(int damage)
    {
        progressBar.value -= damage;
    }
}
