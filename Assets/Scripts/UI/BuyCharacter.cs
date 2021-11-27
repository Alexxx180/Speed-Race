using UnityEngine;
using UnityEngine.UI;

public class BuyCharacter : MonoBehaviour
{
    public int cost = 100;
    public Text money;

    public GameObject lockObject;
    public GameObject forSale;

    public void Buy()
    {
        if (CurrentStats.Coins < cost)
            return;
        CurrentStats.Coins -= cost;
        money.text = CurrentStats.Coins.ToString();
        lockObject.SetActive(false);
        forSale.SetActive(true);
    }
}
