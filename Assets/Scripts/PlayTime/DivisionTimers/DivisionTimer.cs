public class DivisionTimer
{
    public byte[] Time { get; set; }
    private byte[] _intervals { get; set; }
    

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
        if (IsOverFlow())
            return;
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

    

    public void ResetTime()
    {
        for (byte i = 0; i < Time.Length; i++)
            Time[i] = 0;
    }
}