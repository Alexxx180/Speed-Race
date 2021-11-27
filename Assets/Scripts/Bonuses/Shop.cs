using System;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text bonusCount;
    public Text money;
    public int cost = 0;

    public void Buy()
    {
        int value = Convert.ToInt32(money.text);
        if (value < cost)
            return;
        value -= cost;
        money.text = value.ToString();
        Refresh(bonusCount, 1);
    }

    private void Refresh(Text text, int increment)
    {
        int count = Convert.ToInt32(text.text);
        if (count >= 999)
            return;
        count = count + increment;
        text.text = count.ToString();
    }
}
