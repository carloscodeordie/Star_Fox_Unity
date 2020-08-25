using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;

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
        StartDeathFx();
        StartDeathSequence();
    }

    private void StartDeathFx()
    {
        GameObject fx = Instantiate(deathFx, gameObject.transform.position, Quaternion.identity);
        fx.transform.SetParent(parent);
    }

    private void StartDeathSequence()
    {
        Destroy(gameObject);
    }
}
