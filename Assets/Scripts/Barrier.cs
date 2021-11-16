using UnityEngine;

public class Barrier : MonoBehaviour
{
    PlayerStats player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter2D(collision2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.Hurt();
        }
    }
}
