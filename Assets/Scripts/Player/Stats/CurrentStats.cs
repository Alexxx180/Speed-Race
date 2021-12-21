using System.Collections.Generic;

public static class CurrentStats
{
    public static int bonusSelection = 0;
    public static int speedUp = 1;
    public static int coinsMultiplier = 1;

    public static int Score = 0;
    public static int Coins = 0;
    public static readonly int MaxCapacity = 999_999;

    public static string[] BonusNames = { "Shields", "SpeedUp", "Doubler" };
    public static Dictionary<string, ushort> Inventory =
        new Dictionary<string, ushort>()
        {
            { BonusNames[0], 0 },
            { BonusNames[1], 0 },
            { BonusNames[2], 0 }
        };
    public static readonly ushort MaxCount = 999;

    public static DivisionTimer MyTimer = new DivisionTimer(9, 59, 59);

    public static void HardReset()
    {
        MyTimer.ResetTime();
        Coins = 0;
        coinsMultiplier = 1;
        speedUp = 1;
    }
}