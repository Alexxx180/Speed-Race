using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public const int maxHp = 1;
    [Range(0, maxHp)] public int hp = 1;

    public GameObject playground;
    public List<GameObject> bonuses;
    public GameObject menu;

    public Text time;

    public int current = 0;
    public int delay = 50;

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
            CurrentStats.ResetTime();
            time.text = Convert(CurrentStats.Time);
            playground.SetActive(false);
            hp = maxHp;
        }
    }

    private byte[] intervals = { 10, 60, 60 };

    private bool IsOverFlow()
    {
        bool over = false;
        for (byte i = 0; i < intervals.Length; i++)
        {
            over = CurrentStats.Time[i] >= intervals[i] - 1;
            if (!over)
                break;
        }
        return over;
    }

    public string Convert(byte[] times)
    {
        return string.Format("{0:0}'{1:00}'{2:00}",
          times[0], times[1], times[2]);
    }

    public void FixedUpdate()
    {
        current++;
        if (current <= delay)
            return;
        current = 0;
        if (IsOverFlow())
            return;
        for (int i = CurrentStats.Time.Length - 1; i >= 0; i--)
        {
            if (CurrentStats.Time[i] <= intervals[i])
            {
                CurrentStats.Time[i]++;
                break;
            }
            CurrentStats.Time[i] = 0;
        }
        time.text = Convert(CurrentStats.Time);
    }
}
