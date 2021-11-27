using System.Collections.Generic;
using UnityEngine;

public class RandomAppearing : MonoBehaviour
{
    public List<GameObject> obstacles;
    public List<GameObject> appearZones;

    public float minTime = 750f;
    public float maxTime = 1000f;

    public float toTime = 10f;
    public float time = 0f;

    private void CreateObstacle(int kind, int position)
    {
        GameObject obstacle = Instantiate(obstacles[kind]);
        obstacle.transform.SetParent(gameObject.transform);
        obstacle.GetComponent<BarierMoves>().rotateX = position - 1;

        obstacle.transform.position = appearZones[position].transform.position;
        obstacle.transform.localScale = appearZones[position].transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time < toTime)
            return;

        int count = Random.Range(0, 2);
        int kind = Random.Range(0, obstacles.Count);
        int position = Random.Range(0, 3);

        CreateObstacle(kind, position);
        if (count > 0)
        {
            CreateObstacle(kind, Mathf.Abs(position - count));
        }

        toTime = Random.Range(minTime, maxTime); 
        time = 0f;
    }
}
