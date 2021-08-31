using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

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
        
    }

    bool IsEnemyInLane()
    {
        
    }

    public void Shoot()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
}
