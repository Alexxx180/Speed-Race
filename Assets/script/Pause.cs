using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    GameObject player;
    public void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PausePlayer()
    {
        player.SetActive(false);
    }
}
