using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public void Update()
    {
        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();

        foreach (ParticleSystem ps in particleSystems)
        {
            Destroy(ps.gameObject, 1f);
        }
    }
}
