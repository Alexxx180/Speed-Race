using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Timing;
using static CurrentStats;

public class PlayerStats : MonoBehaviour
{
    public const int maxHp = 1;
    [Range(0, maxHp)] public int hp = 1;

    public GameObject playground;
    public List<GameObject> bonuses;
    public GameObject menu;

    public Text time;

    public void NegativeZone()
    {
        for (int i = 0; i < bonuses.Count; i++)
            bonuses[i].SetActive(false);
    }

    private void DestroyObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
            Destroy(obstacle);
    }

    public void Hurt()
    {
        hp--;
        if (hp <= 0)
        {
            menu.SetActive(true);
            NegativeZone();
            DestroyObstacles();
            gameObject.SetActive(false);
            GameObject players = transform.parent.gameObject;
            players.SetActive(false);
            MyTimer.ResetTime();
            time.text = MyTimer.TimerText;
            
            playground.SetActive(false);
            hp = maxHp;
        }
    }

    public void FixedUpdate()
    {
        if (MyTimer.IsOverFlow())
            return;
        if (NoBeat)
            return;
        MyTimer.TimeBeat();
        time.text = MyTimer.TimerText;
    }
}