using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfEnemies = 0;
    bool levelTimerFinished = false;

    public void EnemySpawned()
    {
        numberOfEnemies++;
    }

    public void EnemyKilled()
    {
        numberOfEnemies--;
        if (numberOfEnemies <= 0 && levelTimerFinished)
        {
            Debug.Log("End Level Now");
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        EnemySpawner[] spawnerArray = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
