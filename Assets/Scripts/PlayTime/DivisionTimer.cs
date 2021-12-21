public class DivisionTimer
{
    public byte[] Time { get; set; }
    private byte[] _intervals { get; set; }
    public string TimerText => Convert(Time);

    public DivisionTimer(params byte[] limiter)
    {
        _intervals = limiter;
        Time = new byte[limiter.Length];
        ResetTime();
    }

    public bool IsOverFlow()
    {
        bool over = false;
        for (byte i = 0; i < _intervals.Length; i++)
        {
            over = Time[i] >= _intervals[i] - 1;
            if (!over)
                break;
        }
        return over;
    }

    public void TimeBeat()
    {
        for (int i = Time.Length - 1; i >= 0; i--)
        {
            if (Time[i] < _intervals[i])
            {
                Time[i]++;
                break;
            }
            Time[i] = 0;
        }
    }

    public static string Convert(byte[] times)
    {
        return string.Format("{0:0}'{1:00}'{2:00}",
          times[0], times[1], times[2]);
    }

    public void ResetTime()
    {
        for (byte i = 0; i < Time.Length; i++)
            Time[i] = 0;
    }
}