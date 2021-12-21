using System.Collections.Generic;
using static System.Convert;
using UnityEngine;
using static UnityEngine.Random;
using static CurrentStats;

public class RandomAppearing : MonoBehaviour
{
    public List<GameObject> obstacles;
    public List<GameObject> appearZones;

    private readonly float _minTime = 200f;
    private readonly float _maxTime = 300f;

    private readonly TimeSystem _createTime = new TimeSystem(0, 50);

    private void CreateObstacle(int kind, int position)
    {
        GameObject obstacle = Instantiate(obstacles[kind]);
        obstacle.transform.SetParent(transform);
        obstacle.GetComponent<BarierMoves>().rotateX = position - 1;

        Transform appearZone = appearZones[position].transform;
        obstacle.transform.position = appearZone.position;
        obstacle.transform.localScale = appearZone.localScale;
    }

    // FixedUpdate is called in fixed amount of time
    void FixedUpdate()
    {
        if (_createTime.FullTimeBeat())
            return;
        int delayRange = ToInt32(Range(_minTime, _maxTime));
        _createTime.SetDelay(delayRange / speedUp);

        int count = Range(0, 2);
        int kind = Range(0, obstacles.Count);
        int position = Range(0, 3);

        CreateObstacle(kind, position);
        if (count > 0)
            CreateObstacle(kind, Mathf.Abs(position - count));
    }
}