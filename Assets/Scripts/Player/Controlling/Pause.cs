using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> characters;

    public void PausePlayer()
    {
        player.SetActive(false);
        for (byte i = 0; i < characters.Count; i++)
            characters[i].SetActive(false);
    }
}