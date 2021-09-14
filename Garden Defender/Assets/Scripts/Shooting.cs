using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    Animator animator;
    EnemySpawner myLaneSpawner;

    void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    void Update()
    {
        if (EnemyInSameLane())
            animator.SetBool("isAttacking", true);
        else
            animator.SetBool("isAttacking", false);
    }

    void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);

        if (!projectileParent)
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
    }

    void SetLaneSpawner()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();

        foreach (EnemySpawner spawner in spawners)
        {
            // Checks if a tower is in the same lane as a spawner.
            // "spawners" position - "towers" position should be <= 0
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough)
                myLaneSpawner = spawner;
        }
    }

    bool EnemyInSameLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
            return false;
        else
            return true;
    }

    public void Shoot()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
