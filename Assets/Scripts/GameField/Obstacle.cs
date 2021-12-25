using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    Leaders leader;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Kill the player
            playerMovement.Die();

            leader = collision.gameObject.GetComponent<Leaders>();
            leader.SetFileRecords();
        }   
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shield"))
        {
            PlayerData.bonusesCount[0].time = 1;
            Destroy(gameObject);
            other.gameObject.SetActive(false);
        }
    }
    public void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
            playerMovement = playerObject.GetComponent<PlayerMovement>();
    }
}
