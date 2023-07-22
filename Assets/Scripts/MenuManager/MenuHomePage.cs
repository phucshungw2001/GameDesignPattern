using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuHomePage : MonoBehaviour
{
    public void onBtnPlayClick()
    {
        PlayerPrefs.SetInt("isLoad", 0);
        PlayerPrefs.SetInt("save", 0);
        SceneManager.LoadScene("GameScenes");
        Time.timeScale = 1;
    }

    public void onBtnLoadClick()
    {
        PlayerPrefs.SetInt("isLoad", 1);
        SceneManager.LoadScene("GameScenes");
        Time.timeScale = 1;
    }

    public void onBtnExitClick()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
