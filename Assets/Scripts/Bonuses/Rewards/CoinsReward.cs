using UnityEngine;
using UnityEngine.UI;

public class CoinsReward : Rewards
{
    public Text money;

    public void Awake()
    {
        GameObject moneyObject = GameObject.FindGameObjectWithTag("Money");
        money = moneyObject.GetComponent<Text>();
    }

    public override void Reward()
    {
        CurrentStats.Coins = Mathf.Clamp(CurrentStats.Coins + value * CurrentStats.coinsMultiplier, 0, 999999);
        money.text = CurrentStats.Coins.ToString();
        Destroy(gameObject);
    }
}
