using System;
using UnityEngine;

public class SpeedUpReward : Rewards
{
    public readonly int max = 999;

    public override void Reward()
    {
        int valueMoney = Convert.ToInt32(money.text);
        valueMoney = Mathf.Clamp(valueMoney + value, 0, max);
        money.text = valueMoney.ToString();
        Destroy(gameObject);
    }
}
