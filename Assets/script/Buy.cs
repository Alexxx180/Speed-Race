using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    public int cost = 20;
    public byte selection = 0;

    public void BuyBonus()
    {
        if (PlayreData.Coins >= cost)
        {
            PlayreData.Coins -= cost;
            PlayreData.IncreaseBonusCount(selection, 1);
        }
    }

    public void BuyCharacter()
    {
        if (PlayreData.Coins >= cost)
        {
            PlayreData.Coins -= cost;
            gameObject.SetActive(false);
        }
    }
}
