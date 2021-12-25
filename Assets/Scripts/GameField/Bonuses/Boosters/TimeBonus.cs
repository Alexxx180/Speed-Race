public class TimeBonus
{
    public TimeBonus()
    {
        count = 0;
        time = 0;
        MaxTime = 20;
    }

    public TimeBonus(byte bonusCount) : this()
    {
        count = bonusCount;
    }

    public byte count { get; set; }
    public byte time { get; set; }
    public byte MaxTime { get; set; }
}
