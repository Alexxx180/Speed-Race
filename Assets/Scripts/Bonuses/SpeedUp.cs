public class SpeedUp : Bonuses
{
    public void OnEnable()
    {
        CurrentStats.speedUp = 2;
        FullRefresh();
    }

    public void OnDisable()
    {
        CurrentStats.speedUp = 1;
    }
}
