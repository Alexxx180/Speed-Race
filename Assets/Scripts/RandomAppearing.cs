
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAppearing : MonoBehaviour
{
    public List<GameObject> obstacles;


    public float minTime = 2f;
    public float maxTime = 10f;

    public float toTime = 10f;
    public float time = 0f;

    // Update is called once per frame
    void Update()
    {
        if (time >= toTime)
        {
            GameObject obstacle = Instantiate(obstacles[Random.Range(0, 6)]);
            obstacle.transform.SetParent(gameObject.transform);
            toTime = Random.Range(minTime, maxTime);
            time = 0f;
        }
        time++;
    }
}
