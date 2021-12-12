using UnityEngine;

public class Bonus : MonoBehaviour
{
    public byte increment = 1;
    public byte selection = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }

        PlayreData.IncreaseBonusCount(selection, increment);
        Destroy(gameObject);
    }
}
