using UnityEngine;

public class CoinsReward : Rewards
{
    public readonly int max = 999999;

    public override void Reward()
    {
        CurrentStats.Coins = Mathf.Clamp(CurrentStats.Coins + value * CurrentStats.coinsMultiplier, 0, max);
        money.text = CurrentStats.Coins.ToString();
        Destroy(gameObject);
    }
}
