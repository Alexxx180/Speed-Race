using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    PlayerMovement player;
    public void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<PlayerMovement>();
    }

    public void PausePlayer()
    {
        Debug.Log(player.name);
        player.enabled = !player.enabled;
    }
}
