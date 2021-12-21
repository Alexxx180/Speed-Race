using UnityEngine;
using static CurrentStats;

public class CoinsReward : Rewards
{
    public override void Reward()
    {
        Coins = Mathf.Clamp(Coins + value * coinsMultiplier, 0, MaxCapacity);
        money.text = Coins.ToString();
        Destroy(gameObject);
    }
}