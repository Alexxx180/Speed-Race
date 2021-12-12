using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    Lider lider;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Kill the player
            playerMovement.Die();

            lider = collision.gameObject.GetComponent<Lider>();
            lider.SetFileRecords();
        }   
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shield"))
        {
            PlayreData.bonusesCount[0].time = 1;
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
