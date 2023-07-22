using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    int score = 0;
    public string scoreKey = "Score";
    void Start()
    {
        scoreText.text = "Score: " + score;
        if (PlayerPrefs.GetInt("isLoad") == 1)
        {
            loadScore();
        }
    }

    // Update is called once per frame
    public void incrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void loadScore()
    {
        score = PlayerPrefs.GetInt(scoreKey, 0);
        if (score != 0)
        {
            incrementScore();
        }
    }

    public float getScore()
    {
        return score;
    }

}
