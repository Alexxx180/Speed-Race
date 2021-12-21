public static class Timing
{
    private static readonly TimeSystem _time = new TimeSystem();
    public static bool NoBeat => _time.TimeBeat();

    public static void TimeTick()
    {
        _time.TimeTick();
    }
}