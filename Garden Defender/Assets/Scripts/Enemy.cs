using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Cached Reference
    Animator animator;

    float currentSpeed = 1f;
    GameObject currentTarget;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if (!currentTarget)
            animator.SetBool("isAttacking", false);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget)
            return;

        Health health = currentTarget.GetComponent<Health>();
        if (health)
            health.DealDamage(damage);
    }
}
