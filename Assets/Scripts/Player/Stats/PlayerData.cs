using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
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

    public static FourDivision FourTimer = new FourDivision();

    public static void Timer()
    {
        FourTimer.Beat();
        GameManager.inst.IncrementTime(FourTimer.TimerText);
    }

    public static void ResetBonuses()
    {
        for (byte i = 0; i < bonusesCount.Count; i++)
            bonusesCount[i].count = 0;
    }

    public static void HardReset()
    {
        FourTimer.FullReset();
        ResetBonuses();
        Score = 0;
        Coins = 0;
        bonusSelection = 0;
        coinsMultiplier = 1;
        speedUp = 1;
    }

    public static void UseBonus()
    {
        int select = bonusSelection;
        if (bonusesCount[select].count <= 0)
            return;
        BonusEffects(select, true, 2, 2);
        DecreaseBonusCount(select, 1, 20);
    }

    public static void DropBonusEffect(int select)
    {
        BonusEffects(select, false, 1, 1);
    }

    private static void BonusEffects(int select, bool shieldOn, int speed, int moreCoins)
    {
        switch (select)
        {
            case 0:
                GameManager.inst.shield.SetActive(shieldOn);
                break;
            case 1:
                speedUp = speed;
                break;
            case 2:
            default:
                coinsMultiplier = moreCoins;
                break;
        }
    }
}
