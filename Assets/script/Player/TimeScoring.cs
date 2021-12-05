using UnityEngine;

public class TimeScoring : MonoBehaviour
{
    public int current = 0;
    public int delay = 50;

    public int scoreIncrement = 1;

    public void FixedUpdate()
    {
        current++;
        if (current <= delay)
            return;
        current = 0;
        PlayreData.Timer();
        PlayreData.Score += scoreIncrement * PlayreData.speedUp;
        for (int i = 0; i < PlayreData.bonusesCount.Count; i++)
            if (!PlayreData.bonusesCantDrop[i])
                PlayreData.DropBonusEffect(i);
    }
}
