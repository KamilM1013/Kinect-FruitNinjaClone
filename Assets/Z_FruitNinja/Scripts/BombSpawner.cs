using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{

    public GameObject bombPrefab;
    public Transform[] bombSpawnPoints;

    public float minDelay = .1f;
    public float maxDelay = 1f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnBombs());
    }

    IEnumerator SpawnBombs()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int bombSpawnIndex = Random.Range(0, bombSpawnPoints.Length);
            Transform bombSpawnPoint = bombSpawnPoints[bombSpawnIndex];

            GameObject spawnedBomb = Instantiate(bombPrefab, bombSpawnPoint.position, bombSpawnPoint.rotation);
            Destroy(spawnedBomb, 5f);
        }
    }

}
