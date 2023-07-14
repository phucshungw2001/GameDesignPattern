﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;

    private void Start()
    {
        HideGameOverUI();
    }

    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void HideGameOverUI()
    {
        gameOverUI.SetActive(false);
    }

    public void NewGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
