using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    // Cached Reference
    Animator animator;
    Enemy enemy;

    private void Start()
    {
        animator = GetComponent<Animator>(); 
        enemy = GetComponent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Gravestone>())
            animator.SetTrigger("jumpTrigger");
        else if (otherObject.GetComponent<Tower>())
            enemy.Attack(otherObject);
    }
}
