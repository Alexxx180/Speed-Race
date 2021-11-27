public static class CurrentStats
{
    public static int bonusSelection = 0;
    public static int speedUp = 1;
    public static int coinsMultiplier = 1;

    public static int Score = 0;
    public static int Coins = 0;
    public static int Shields = 0;
    public static int SpeedUp = 0;
    public static int Doubler = 0;

    public static byte[] Time = { 0, 0, 0 };

    public static void ResetTime()
    {
        for (byte i = 0; i < Time.Length; i++)
            Time[i] = 0;
    }

    public static void HardReset()
    {
        ResetTime();
        Coins = 0;
        Shields = 0;
        SpeedUp = 0;
        Doubler = 0;
        coinsMultiplier = 1;
        speedUp = 1;
    }
}
