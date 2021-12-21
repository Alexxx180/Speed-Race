using UnityEngine;
using UnityEngine.UI;
using static Timing;

public class Bonuses : MonoBehaviour
{
    public Text duration;
    private int _time = 20;
    private readonly int _maxTime = 20;

    public void FullRefresh()
    {
        TimeRefresh(_maxTime);
    }

    private void TimeRefresh(int toDestroy)
    {
        _time = toDestroy;
        duration.text = _time.ToString();
    }

    public void DestroyBonus()
    {
        gameObject.SetActive(false);
    }

    private void DecreaseDuration()
    {
        TimeRefresh(_time - 1);
        if (_time <= 0)
            DestroyBonus();
    }

    void FixedUpdate()
    {
        if (NoBeat)
            return;
        DecreaseDuration();
    }
}
