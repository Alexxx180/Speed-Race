
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAppearing : MonoBehaviour
{
    public List<GameObject> obstacles;
    public List<GameObject> appearZones;

    public float minTime = 2000f;
    public float maxTime = 10000f;

    public float toTime = 10f;
    public float time = 0f;

    // Update is called once per frame
    void Update()
    {
        if (time >= toTime)
        {
            int i = Random.Range(0, 2);
            int pos = Random.Range(0, 3);

            GameObject obstacle = Instantiate(obstacles[i]);
            obstacle.transform.SetParent(gameObject.transform);
            obstacle.transform.position = appearZones[pos].transform.position;

            toTime = Random.Range(minTime, maxTime);
            time = 0f;
        }
        time++;
    }
}
