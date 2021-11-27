using System;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text score;
    public int scoreIncrement;
    public int delay = 100;
    public int current = 0;

    public string GetScore()
    {
        return score.text;
    }

    public void SetScore()
    {
        int scoreValue = Convert.ToInt32(GetScore());
        CurrentStats.Score = scoreValue + scoreIncrement * CurrentStats.speedUp;
        score.text = "" + CurrentStats.Score;
    }

    void FixedUpdate()
    {
        current++;
        if (current > delay)
        {
            current = 0;
            SetScore();
        }
    }
}
