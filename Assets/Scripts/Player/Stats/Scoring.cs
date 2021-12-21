using static System.Convert;
using static CurrentStats;
using static Timing;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text score;
    public int scoreIncrement;
    private int _scoreValue => ToInt32(GetScore());
    private const int MaxValue = 999_999_999;
    
    public string GetScore()
    {
        return score.text;
    }

    public void SetScore()
    {
        Score = _scoreValue + scoreIncrement * speedUp;
        score.text = Score.ToString();
    }

    void FixedUpdate()
    {
        if (_scoreValue >= MaxValue)
            return;
        if (NoBeat)
            return;
        SetScore();
    }
}