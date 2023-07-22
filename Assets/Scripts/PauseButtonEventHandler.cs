using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtonEventHandler : MonoBehaviour
{
    private GameObject _pauseGamePanel;
    private GameObject _settingPanel;
    private GameObject _informationButton;
    private GameObject _informationText;
    private bool _enabled = false;
    public string scoreKey = "Score";
    public string healthKey = "health";
    private Slider progressBar;

    // Start is called before the first frame update
    void Start()
    {
        _pauseGamePanel = GameObject.Find("PauseGamePanel");
        _settingPanel = GameObject.Find("SettingPanel");
        _informationButton = GameObject.Find("InfoButton");
        _informationText = GameObject.Find("InformationText");

        _pauseGamePanel.SetActive(false);
        _settingPanel.SetActive(false);
        _informationButton.SetActive(false);
        _informationText.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _pauseGamePanel.SetActive(true);
        _informationButton.SetActive(true);
    }


    public void ContinueGame()
    {
        Time.timeScale = 1;
        _pauseGamePanel.SetActive(false);
    }


    public void SaveGame()
    {
        PlayerPrefs.SetInt("save", 1);
        Score socreSave = FindObjectOfType<Score>();
        float score = socreSave.getScore();
        PlayerPrefs.SetInt(scoreKey, (int)score);
        
        Health health = FindObjectOfType<Health>();
        float healthValue = health.getHealth();
        PlayerPrefs.SetInt(healthKey, (int)healthValue);
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



    public void Information()
    {
        if (!_enabled)
        {
            _enabled = true;
            _informationText.SetActive(true);
            _pauseGamePanel.SetActive(false);
        }
        else
        {
            _enabled = false;
            _pauseGamePanel.SetActive(true);
            _informationText.SetActive(false);
        }
    }
}
