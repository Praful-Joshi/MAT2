using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] Obstacles;
    public GameObject[] spawnPoints;

    public float respawnTime = 1.0f;
    private Vector3 spawnPos;

    void Start()
    {
        RandomPositionGenerator();
        StartCoroutine(spawnWave());
    }

    void Update()
    {
        RandomPositionGenerator();
    }

    private void SpawnEnemy()
    {
        GameObject a = Instantiate(Obstacles[Random.Range(0, 4)]) as GameObject;
        a.transform.position = spawnPos;
    }

    public void RandomPositionGenerator()
    {
        spawnPos = spawnPoints[Random.Range(0, 5)].transform.position;
    }

    IEnumerator spawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }

    }
}
