using UnityEngine;
using UnityEngine.UI;

public abstract class Rewards : MonoBehaviour
{
    public string bonus = "Money";
    public Text money;
    public int value = 5;

    public void Awake()
    {
        GameObject moneyObject = GameObject.FindGameObjectWithTag(bonus);
        money = moneyObject.GetComponent<Text>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Reward();
        }
    }

    public abstract void Reward();
}
