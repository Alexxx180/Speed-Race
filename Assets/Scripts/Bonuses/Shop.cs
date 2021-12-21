using static System.Convert;
using UnityEngine;
using UnityEngine.UI;
using static CurrentStats;

public class Shop : MonoBehaviour
{
    public string type;
    public Text bonusCount;
    public Text money;
    public int cost = 0;

    public void Buy()
    {
        if (Coins < cost)
            return;
        Refresh(bonusCount, 1);
    }

    private void Refresh(Text amount, int increment)
    {
        if (Inventory[type] >= MaxCount)
            return;
        Coins -= cost;
        money.text = Coins.ToString();
        Inventory[type] += ToUInt16(increment);
        amount.text = Inventory[type].ToString();
    }
}