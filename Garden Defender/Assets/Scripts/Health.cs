using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    GameObject vfxParent;
    const string VFX_PARENT_NAME = "VFX";

    void Start()
    {
        CreateVFXParent();
    }

    void CreateVFXParent()
    {
        vfxParent = GameObject.Find(VFX_PARENT_NAME);

        if (!vfxParent)
            vfxParent = new GameObject(VFX_PARENT_NAME);
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DeathVFX();
            Destroy(gameObject);
        }
    }

    void DeathVFX()
    {
        if (!deathVFX)
            return;
        
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity) as GameObject;
        deathVFXObject.transform.parent = vfxParent.transform;
        Destroy(deathVFXObject, 5f);
    }
}
