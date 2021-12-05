using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager inst;

    public Text scoreText;
    public Text moneyText;
    public Text timeText;

    public List<Text> bonuses;

    private void Increment(Text text, int value)
    {
        text.text = value.ToString();
    }

    private void Increment(Text text, string value)
    {
        text.text = value;
    }

    public void IncrementScore(int value) {
        Increment(scoreText, value);
    }

    public void IncrementMoney(int value)
    {
        Increment(moneyText, value);
    }

    public void IncrementTime(string value)
    {
        Increment(timeText, value);
    }

    public void IncrementBonus(int selection, int value)
    {
        Increment(bonuses[selection], value);
    }

    private T TryGetObject<T>(string name)
    {
        GameObject gameObject = GameObject.Find(name);
        if (gameObject == null)
            return default;
        return gameObject.GetComponent<T>();
    }

    private void Awake()
    {
        inst = this;
        scoreText = TryGetObject<Text>("ScoreText");
        moneyText = TryGetObject<Text>("MoneyText");
        timeText = TryGetObject<Text>("TimeText");
    }
}
