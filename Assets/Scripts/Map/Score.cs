using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    int score = -1;
    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    public void incrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
