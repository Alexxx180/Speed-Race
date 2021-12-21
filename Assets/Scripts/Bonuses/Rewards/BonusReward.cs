using static System.Convert;
using static UnityEngine.Mathf;
using static CurrentStats;

public class BonusReward : Rewards
{
    public override void Reward()
    {
        Inventory[bonus] = ToUInt16(Clamp(Inventory[bonus] + value, 0, MaxCount));
        money.text = Inventory[bonus].ToString();
        Destroy(gameObject);
    }
}