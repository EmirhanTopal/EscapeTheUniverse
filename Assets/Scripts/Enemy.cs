using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathParticle;

    [SerializeField] private Transform parent;
    private void OnParticleCollision(GameObject other)
    {
        GameObject parentObj = Instantiate(deathParticle, transform.position, quaternion.identity);
        parentObj.transform.parent = parent;
        Destroy(this.gameObject);
    }
}
