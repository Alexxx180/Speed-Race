using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject menu;
    public GameObject playerObject;
    public List<GameObject> toPause;

    public void PauseEnvironment()
    {
        menu.SetActive(true);

        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerObject.SetActive(false);

        gameObject.SetActive(false);

        for (int i = 0; i < toPause.Count; i++)
        {
            toPause[i].SetActive(false);
        }
    }

    public void UnPause()
    {
        menu.SetActive(false);
        gameObject.SetActive(true);

        playerObject.SetActive(true);

        for (int i = 0; i < toPause.Count; i++)
        {
            toPause[i].SetActive(true);
        }
    }

    public void QuitToPlayers()
    {
        CurrentStats.HardReset();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PauseEnvironment();
        }
    }
}
