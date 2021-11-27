using UnityEngine;

public class ShieldReward : Rewards
{
    public readonly int max = 999;

    public override void Reward()
    {
        CurrentStats.Shields = Mathf.Clamp(CurrentStats.Shields + value, 0, max);
        money.text = CurrentStats.Shields.ToString();
        Destroy(gameObject);
    }
}
