using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    EnemySpawner myLaneSpawner;

    private void Start()
    {
        SetLaneSpawner();
    }

    private void Update()
    {
        if (IsEnemyInLane())
        {
            Debug.Log("Shoot");
            // TODO: Change Animation State to Shooting
        }
        else
        {
            Debug.Log("Wait");
            // TODO: Change Animation State to Idle.
        }
    }

    void SetLaneSpawner()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();

        foreach (EnemySpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (IsCloseEnough)
                myLaneSpawner = spawner;
        }
    }

    bool IsEnemyInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
            return false;
        else
            return true;
    }

    public void Shoot()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
}
