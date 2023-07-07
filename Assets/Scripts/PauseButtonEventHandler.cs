using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonEventHandler : MonoBehaviour
{

    private GameObject _pauseGamePanel;
    private GameObject _settingPanel;

    // Start is called before the first frame update
    void Start()
    {
        _pauseGamePanel = GameObject.Find("PauseGamePanel");
        _settingPanel = GameObject.Find("SettingPanel");

        _pauseGamePanel.SetActive(false);
        _settingPanel.SetActive(false);
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


    public void Setting()
    {
        _pauseGamePanel.SetActive(false);
        _settingPanel.SetActive(true);
    }



    public void TurnOnMusic()
    {
        AudioListener.pause = false;
    }


    public void TurnOffMusic()
    {
        AudioListener.pause = true;
    }


    public void BackToPausePanel()
    {
        _settingPanel.SetActive(false);
        _pauseGamePanel.SetActive(true);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
