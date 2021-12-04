using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    Lider lider;
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Kill the player
            playerMovement.Die();

            lider = collision.gameObject.GetComponent<Lider>();
            lider.SetFileRecords();
        }   
    }
    void Update()
    {
        
    }
}
