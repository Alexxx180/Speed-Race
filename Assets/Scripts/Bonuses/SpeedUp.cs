public class Doubler : Bonuses
{
    public void OnEnable()
    {
        CurrentStats.coinsMultiplier = 2;
        FullRefresh();
    }

    public void OnDisable()
    {
        CurrentStats.coinsMultiplier = 1;
    }
}
