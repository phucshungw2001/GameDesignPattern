using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monter : MonoBehaviour
{
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        Vector3 bulletViewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (bulletViewportPosition.x < 0 || bulletViewportPosition.x > 1 ||
            bulletViewportPosition.y < 0 || bulletViewportPosition.y > 1)
        {
            gameObject.SetActive(false);
        }
    }
}
