using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;  // Список префабов препятствий
    public int numberOfObstacles = 10;  // Количество препятствий
    public Vector3 spawnAreaMin = new Vector3(-10, 0, -10);  // Минимальные координаты области спавна
    public Vector3 spawnAreaMax = new Vector3(10, 0, 10);  // Максимальные координаты области спавна

    void Start()
    {
        SpawnObstacles();
    }

    void SpawnObstacles()
    {
        for (int i = 0; i < numberOfObstacles; i++)
        {
            Vector3 spawnPosition = GetRandomPosition();
            GameObject obstaclePrefab = GetRandomObstacle();
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float z = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        return new Vector3(x, y, z);
    }

    GameObject GetRandomObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Count);
        return obstaclePrefabs[index];
    }
}
