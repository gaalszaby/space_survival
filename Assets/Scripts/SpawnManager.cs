using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPreFab;
    public GameObject player;
    private float spawnRange = 10f;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    private Vector2 GenerateRandomPos()
    {
        float spawnPosX = Random.Range(-spawnRange - 2, spawnRange + 2);
        float spawnPosY = Random.Range(-spawnRange - 2, spawnRange + 2);
        Vector2 randomPos = new Vector2(player.transform.position.x + spawnPosX, player.transform.position.y + spawnPosY);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPreFab, GenerateRandomPos(), enemyPreFab.transform.rotation);
        }
    }
}
