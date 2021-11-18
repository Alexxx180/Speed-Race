using UnityEngine;

public class Barrier : MonoBehaviour
{
    public PlayerStats player;

    private void Awake()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("BOOOM!");
            player.Hurt();
        }
    }
}
