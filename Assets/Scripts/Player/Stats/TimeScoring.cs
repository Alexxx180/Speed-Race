using UnityEngine;
using static PlayerData;
using static Timing;

public class TimeScoring : MonoBehaviour
{
    public int scoreIncrement = 1;

    public void FixedUpdate()
    {
        if (NoBeat)
            return;
        Timer();
        Score += scoreIncrement * speedUp;
    }
}
