using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject menu;
    public GameObject playerObject;
    public List<GameObject> toPause;

    public void PauseEnvironment()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        Turn(false);
    }

    public void UnPause()
    {
        Turn(true);
    }

    private void Turn(bool activate)
    {
        playerObject.SetActive(activate);
        gameObject.SetActive(activate);
        menu.SetActive(!activate);

        for (int i = 0; i < toPause.Count; i++)
            toPause[i].SetActive(activate);
    }

    public void QuitToPlayers()
    {
        CurrentStats.HardReset();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            PauseEnvironment();
    }
}