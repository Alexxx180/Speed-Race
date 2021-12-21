public class TimeSystem
{
    private int Ticks { get; set; }
    private int Delay { get; set; }

    public TimeSystem() : this(0, 50)
    {
    }

    public TimeSystem(int ticks, int delay)
    {
        Ticks = ticks;
        SetDelay(delay);
    }

    public void SetDelay(int delay)
    {
        Delay = delay;
    }

    // Actual time beat
    public bool TimeBeat()
    {
        return Ticks < Delay;
    }

    // Game-in time ticks
    public void TimeTick()
    {
        Ticks++;
        if (Ticks > Delay)
            Ticks = 0;
    }

    // Time tick with actual time beat recording
    public bool FullTimeBeat()
    {
        TimeTick();
        if (TimeBeat())
            return true;
        TimeTick();
        return false;
    }
}