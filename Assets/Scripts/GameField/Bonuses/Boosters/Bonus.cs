using UnityEngine;

public class Bonus : MonoBehaviour
{
    public byte increment = 1;
    public byte selection = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        if (!other.gameObject.CompareTag("Player"))
            return;

        PlayerData.IncreaseBonusCount(selection, increment);
        Destroy(gameObject);
    }
}
