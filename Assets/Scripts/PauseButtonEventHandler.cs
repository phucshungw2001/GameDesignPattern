using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonEventHandler : MonoBehaviour
{

    private GameObject _pauseGamePanel;

    // Start is called before the first frame update
    void Start()
    {
        _pauseGamePanel = GameObject.Find("PauseGamePanel");
        _pauseGamePanel.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _pauseGamePanel.SetActive(true);
    }


    public void ContinueGame()
    {
        Time.timeScale = 1;
        _pauseGamePanel.SetActive(false);
    }


    public void SaveGame()
    {
        // TODO
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
