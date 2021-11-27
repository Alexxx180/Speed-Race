using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public const int maxHp = 1;
    [Range(0, maxHp)] public int hp = 1;

    public GameObject playground;

    public List<GameObject> bonuses;

    public GameObject menu;

    public void NegativeZone()
    {
        for (int i = 0; i < bonuses.Count; i++)
            bonuses[i].SetActive(false);
    }

    public void Hurt()
    {
        hp--;
        if (hp <= 0)
        {
            menu.SetActive(true);
            NegativeZone();
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (GameObject obstacle in obstacles)
                Destroy(obstacle);
            gameObject.SetActive(false);
            playground.SetActive(false);
            hp = maxHp;
        }
    }

    
}
