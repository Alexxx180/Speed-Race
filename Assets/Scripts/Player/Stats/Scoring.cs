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
        string text = score.text;
        return text.Substring(text.LastIndexOf(" ") + 1);
    }

    public void SetScore()
    {
        int scoreValue = Convert.ToInt32(GetScore());
        score.text = "" + (scoreValue + scoreIncrement * CurrentStats.speedUp);
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
