using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0.1f, 3f)] [SerializeField] float walkSpeed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
    }
}
