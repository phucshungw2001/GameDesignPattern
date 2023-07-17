using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuHomePage : MonoBehaviour
{
    public void onBtnPlayClick()
    {
        SceneManager.LoadScene("GameScenes");
        Time.timeScale = 1;
    }

    public void onBtnLoadClick()
    {
        SceneManager.LoadScene("GameScenes");
        Time.timeScale = 1;
    }

    public void onBtnExitClick()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
