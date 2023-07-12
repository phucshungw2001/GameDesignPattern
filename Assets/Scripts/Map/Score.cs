using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    int score = 0;
    float time;
    float timeIncrementScore=1f;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        time = timeIncrementScore;
    }

    // Update is called once per frame
    public void incrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if (time<=0)
        {
            incrementScore();
            time = timeIncrementScore;
        }
        
    }
}
