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
    }

    public void onBtnLoadClick()
    {
        SceneManager.LoadScene("GameScenes");
    }

    public void onBtnExitClick()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
