using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider enemyBoxCollider = gameObject.AddComponent<BoxCollider>() as BoxCollider;
        enemyBoxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        Destroy(gameObject);
    }
}
