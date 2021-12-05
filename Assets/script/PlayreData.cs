using System.Collections.Generic;
using UnityEngine;

public static class PlayreData
{
    public static GameObject shield;

    public static string passName { get; set; }
    public static int no { get; set; }

    public static int bonusSelection = 0;
    public static int speedUp = 1;
    public static int coinsMultiplier = 1;

    public static List<TimeBonus> bonusesCount = new List<TimeBonus>() {
        new TimeBonus(), new TimeBonus(), new TimeBonus()
    };

    public static int Score {
        get { return _score; }
        set
        {
            _score = Mathf.Min(value, int.MaxValue);
            GameManager.inst.IncrementScore(value);
        }
    }
    public static int Coins {
        get { return _coins; }
        set {
            _coins = Mathf.Min(value, int.MaxValue);
            GameManager.inst.IncrementMoney(value);
        }
    }

    public static void IncreaseBonusCount(int selection, byte increment)
    {
        bonusesCount[selection].count += increment;
        GameManager.inst.IncrementBonus(selection, bonusesCount[selection].count);
    }

    public static bool DecreaseBonusCount(int selection, byte decrement, byte time)
    {
        if (bonusesCount[selection].time > 0)
            return false;
        bonusesCount[selection].count -= decrement;
        GameManager.inst.IncrementBonus(selection, bonusesCount[selection].count);
        bonusesCount[selection].time = time;
        return true;
    }

    private static int _score = 0;
    private static int _coins = 0;

    public static byte[] Time = { 0, 0, 0, 0 };
    public static readonly byte[] Intervals = { 100, 24, 59, 59 };

    private static bool IsOverFlow()
    {
        bool over = false;
        for (byte i = 0; i < Intervals.Length; i++)
        {
            over = Time[i] >= Intervals[i] - 1;
            if (!over)
                break;
        }
        return over;
    }

    public static string Convert(byte[] times)
    {
        return string.Format("{0:0}'{1:00}'{2:00}'{3:00}",
          times[0], times[1], times[2], times[3]);
    }

    public static void Timer()
    {
        if (IsOverFlow())
            return;
        for (int i = Time.Length - 1; i >= 0; i--)
        {
            if (Time[i] < Intervals[i])
            {
                Time[i]++;
                break;
            }
            Time[i] = 0;
        }
        GameManager.inst.IncrementTime(Convert(Time));
    }

    public static void ResetTime()
    {
        for (byte i = 0; i < Time.Length; i++)
            Time[i] = 0;
    }

    public static void ResetBonuses()
    {
        for (byte i = 0; i < bonusesCount.Count; i++)
            bonusesCount[i].count = 0;
    }

    public static void HardReset()
    {
        ResetTime();
        ResetBonuses();
        Coins = 0;
        Score = 0;
        coinsMultiplier = 1;
        speedUp = 1;
    }

    public static void UseBonus()
    {
        int select = bonusSelection;
        if (bonusesCount[select].count <= 0)
            return;
        switch (bonusSelection)
        {
            case 0:
                shield.SetActive(true);
                break;
            case 1:
                speedUp = 2;
                break;
            case 2:
            default:
                coinsMultiplier = 2;
                break;
        }
        DecreaseBonusCount(select, 1, 20);
    }

    public static bool[] bonusesCantDrop => new bool[] { !shield.activeSelf, speedUp <= 1, coinsMultiplier <= 1 };

    public static void DropBonusEffect(int select)
    {
        if (bonusesCount[select].time > 0)
            return;
        switch (bonusSelection)
        {
            case 0:
                shield.SetActive(false);
                break;
            case 1:
                speedUp = 1;
                break;
            case 2:
            default:
                coinsMultiplier = 1;
                break;
        }
        DecreaseBonusCount(select, 1, 20);
    }
}
