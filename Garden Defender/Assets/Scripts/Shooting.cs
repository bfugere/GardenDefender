using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    public void Shoot()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
}