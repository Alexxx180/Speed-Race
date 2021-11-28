using System;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text score;
    public int scoreIncrement;
    public int delay = 100;
    public int current = 0;
    private int _scoreValue => Convert.ToInt32(GetScore());
    
    public string GetScore()
    {
        return score.text;
    }

    public void SetScore()
    {
        CurrentStats.Score = _scoreValue + scoreIncrement * CurrentStats.speedUp;
        score.text = "" + CurrentStats.Score;
    }

    void FixedUpdate()
    {
        if (_scoreValue >= 999_999_999)
            return;
        current++;
        if (current > delay)
        {
            current = 0;
            SetScore();
        }
    }
}
