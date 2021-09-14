using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int minSpawnDelay;
    int maxSpawnDelay;
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
                minSpawnDelay = 1;
                maxSpawnDelay = 5;
                break;
            case 1:
                minSpawnDelay = 3;
                maxSpawnDelay = 7;
                break;
            default:
                minSpawnDelay = 5;
                maxSpawnDelay = 10;
                break;
        }
    }
}
