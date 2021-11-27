using UnityEngine;

public class DoublerReward : Rewards
{
    public readonly int max = 999;

    public override void Reward()
    {
        CurrentStats.Doubler = Mathf.Clamp(CurrentStats.Shields + value, 0, max);
        money.text = CurrentStats.Doubler.ToString();
        Destroy(gameObject);
    }
}
