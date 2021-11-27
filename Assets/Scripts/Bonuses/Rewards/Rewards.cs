using UnityEngine;

public abstract class Rewards : MonoBehaviour
{
    public int value = 5;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Reward();
        }
    }

    public abstract void Reward();
}
