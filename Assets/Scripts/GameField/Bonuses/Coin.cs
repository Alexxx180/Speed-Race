using UnityEngine;
using static PlayerData;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;
    public int value = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        if (!other.gameObject.CompareTag("Player"))
            return;

        Score += value * 2;
        Coins += value * coinsMultiplier;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
