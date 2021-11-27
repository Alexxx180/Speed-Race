using UnityEngine;
using UnityEngine.UI;

public class Bonuses : MonoBehaviour
{
    public Text duration;
    public int delay = 10;
    public int current = 0;
    public int time = 20;
    public int maxTime = 20;

    public void FullRefresh()
    {
        current = 0;
        TimeRefresh(maxTime);
    }

    private void TimeRefresh(int toDestroy)
    {
        time = toDestroy;
        duration.text = time.ToString();
    }

    public void DestroyBonus()
    {
        gameObject.SetActive(false);
    }

    private void DecreaseDuration()
    {
        TimeRefresh(time - 1);
    }

    void FixedUpdate()
    {
        if (time <= 0)
        {
            DestroyBonus();
            return;
        }
        current++;
        if (current > delay)
        {
            current = 0;
            DecreaseDuration();
        }
    }
}
