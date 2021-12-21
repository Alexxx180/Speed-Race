using UnityEngine;
using UnityEngine.UI;
using static CurrentStats;

public class BuyCharacter : MonoBehaviour
{
    public int cost = 100;
    public Text money;

    public GameObject lockObject;
    public GameObject forSale;

    public void Buy()
    {
        if (Coins < cost)
            return;
        Coins -= cost;
        money.text = Coins.ToString();
        Unlock();
    }

    private void Unlock()
    {
        lockObject.SetActive(false);
        forSale.SetActive(true);
    }
}