using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnObject;
    public int numEnemies = 3;
    private int enemyCount;
    private Vector3 spawnPos;
    public float spawnRange = 10;
    public GameObject powerup;
    void Start()
    {
        SpawnEnemyWave();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<FollowPlayer>().Length;
        if(enemyCount < 1)
        {
            SpawnEnemyWave();
        }
    }

    void SpawnEnemyWave()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            print("Spawning");
            spawnPos = generatePos();
            Instantiate(spawnObject, spawnPos, spawnObject.transform.rotation);
        }
        spawnPos = generatePos();
        Instantiate(powerup, spawnPos, spawnObject.transform.rotation);
        numEnemies += 1;
    }

    Vector3 generatePos()
    {
        return new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
    }
}
