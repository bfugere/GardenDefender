using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float minSpawnDelay;
    float maxSpawnDelay;
    [SerializeField] Enemy[] enemyPrefabArray;

    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            CalculateDifficultySpawnRate();

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));

            if (spawn)
            {
                SpawnEnemy();
            }
        }
        spawn = false;
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    void SpawnEnemy()
    {
        var enemyIndex = Random.Range(0, enemyPrefabArray.Length);
        Spawn(enemyPrefabArray[enemyIndex]);
    }

    void Spawn(Enemy enemy)
    {
        Enemy newEnemy = Instantiate(enemy, transform.position, Quaternion.identity) as Enemy;
        newEnemy.transform.parent = transform;
    }

    public void CalculateDifficultySpawnRate()
    {
        switch (PlayerPrefsController.GetDifficulty())
        {
            case 2:
                minSpawnDelay = 2f;
                maxSpawnDelay = 4f;
                break;
            case 1:
                minSpawnDelay = 4f;
                maxSpawnDelay = 8f;
                break;
            default:
                minSpawnDelay = 8f;
                maxSpawnDelay = 16f;
                break;
        }
    }
}
