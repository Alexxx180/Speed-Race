using UnityEngine;
using static Timing;

public class Timer : MonoBehaviour
{
    // FixedUpdate is called in fixed amount of time
    void FixedUpdate()
    {
        TimeTick();
    }
}