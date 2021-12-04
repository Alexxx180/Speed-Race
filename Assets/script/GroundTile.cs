using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawer groundSpawner;
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawer>();
        SpawnObstacle();
        SpawnCoins();
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject obstraclePrefab;

    void SpawnObstacle() {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex);

        Instantiate(obstraclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
    public GameObject coinPrefab;

    void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++) 
        {
          GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPoinInCollider(GetComponent<Collider>());
        }
    }
    Vector3 GetRandomPoinInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point)) {
            point = GetRandomPoinInCollider(collider);
        }
        point.y = 1;
        return point;
    }
}
