using UnityEngine;
using static PlayerData;

public class Buy : MonoBehaviour
{
    public int cost = 20;
    public byte selection = 0;

    public void BuyBonus()
    {
        if (Coins >= cost)
        {
            Coins -= cost;
            IncreaseBonusCount(selection, 1);
        }
    }

    public void BuyCharacter()
    {
        if (Coins >= cost)
        {
            Coins -= cost;
            gameObject.SetActive(false);
        }
    }
}