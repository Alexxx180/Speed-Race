﻿using UnityEngine;

public class Barrier : MonoBehaviour
{
    public PlayerStats player;
    public RandomAppearing moves;
    public Leaders leaders;

    public void Awake()
    {
        if (player != null)
            return;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject == null)
        {
            Destroy(gameObject);
            GameObject fieldObject = GameObject.FindGameObjectWithTag("Field");
            moves = fieldObject.GetComponent<RandomAppearing>();
            moves.enabled = false;
            return;
        }
        player = playerObject.GetComponent<PlayerStats>();
        leaders = playerObject.GetComponent<Leaders>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            player.Hurt();
            leaders.SetFileRecords();
        }
    }
}