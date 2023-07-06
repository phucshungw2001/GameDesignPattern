using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtonEventHandler : MonoBehaviour
{

    private GameObject _pauseGamePanel;
    private GameObject _settingPanel;
    private GameObject _infomation;
    private GameObject _informationText;
    private bool _informationEnabled = false;

    // Start is called before the first frame update
    void Start()
    {

        _pauseGamePanel = GameObject.Find("PauseGamePanel");
        _settingPanel = GameObject.Find("SettingPanel");
        _infomation = GameObject.Find("BtnInfo");
        _informationText = GameObject.Find("PlayerInfomation");

        _pauseGamePanel.SetActive(false);
        _settingPanel.SetActive(false);
        _infomation.SetActive(false);
        _informationText.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _pauseGamePanel.SetActive(true);
        _infomation.SetActive(true);
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

    public void Infomation()
    {

        if (!_informationEnabled)
        {
            _pauseGamePanel.SetActive(false);
            _informationText.SetActive(true);
            _informationEnabled = true;
        }
        else
        {
            _informationText.SetActive(false);
            _informationEnabled = false;
        }

        //_settingPanel.SetActive(false);
        //_infomation.SetActive(true);
    }
}
