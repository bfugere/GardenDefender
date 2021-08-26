using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float rotationSpeed = 750f;
    [SerializeField] float projectileDamage = 50f;

    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime, Space.World);
        transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Health health = otherCollider.GetComponent<Health>();
        health.DealDamage(projectileDamage);
    }
}
