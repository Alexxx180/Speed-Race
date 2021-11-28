using UnityEngine;

public class SpeedUpReward : Rewards
{
    public readonly int max = 999;

    public override void Reward()
    {
        CurrentStats.SpeedUp = Mathf.Clamp(CurrentStats.SpeedUp + value, 0, max);
        money.text = CurrentStats.SpeedUp.ToString();
        Destroy(gameObject);
    }
}
