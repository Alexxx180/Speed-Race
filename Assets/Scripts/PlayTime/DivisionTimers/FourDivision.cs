public class FourDivision : IDivision
{
    public DivisionTimer Timer = new DivisionTimer(9, 23, 59, 59);
    public string TimerText => Convert(Timer.Time);

    public string Convert(byte[] divisions)
    {
        return string.Format("{0:0}:{1:00}:{2:00}:{3:00}",
          divisions[0], divisions[1], divisions[2], divisions[3]);
    }

    public void Beat()
    {
        Timer.TimeBeat();
    }

    public void FullReset()
    {
        Timer.ResetTime();
    }
}