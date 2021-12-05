using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (! other.gameObject.CompareTag("Player")) {
            return;
        }
        
        PlayreData.Coins += value * PlayreData.coinsMultiplier;

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
