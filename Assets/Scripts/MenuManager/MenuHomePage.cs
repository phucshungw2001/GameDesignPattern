using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuHomePage : MonoBehaviour
{

/*    public string scoreKey = "Score";*/
    public void onBtnExitClick()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void onBtnStartClick()
    {
/*        PlayerPrefs.SetInt("isLoad", 0);
        PlayerPrefs.SetInt("save", 0);*/
        SceneManager.LoadScene("GameScenes");
    }

    public void onBtnLoadClick()
    {
/*        PlayerPrefs.SetInt("isLoad", 1);*/
        SceneManager.LoadScene("GameScenes");
    }

    public void onBtnSaveClick()
    {
      
    }

}
