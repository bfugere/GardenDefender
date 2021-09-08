using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 5f;
    [SerializeField] GameObject victoryTextPopup;
    [SerializeField] GameObject loseTextPopup;
    int numberOfEnemies = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        victoryTextPopup.SetActive(false);
        loseTextPopup.SetActive(false);
    }

    public void EnemySpawned()
    {
        numberOfEnemies++;
    }

    public void EnemyKilled()
    {
        numberOfEnemies--;
        if (numberOfEnemies <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        victoryTextPopup.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseTextPopup.SetActive(true);
        Time.timeScale = 0;
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

        if (numberOfEnemies <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }
}
