using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParticleManager : MonoBehaviour
{
    private static event Action<ParticleSystem> OnParticle;

    private void Awake()
    {
        OnParticle += PlayParticle;
    }

    public void StopParticle()
    {
        OnParticle -= PlayParticle;
    }
    // logic hatırlaması yapılacak.
    void PlayParticle(ParticleSystem particleSystem2)
    {
        if (particleSystem2 != null)
        {
            particleSystem2.Play();
        }
    }

    public static void TriggerPlayParticle(ParticleSystem particleSystem)
    {
        OnParticle?.Invoke(particleSystem);
    }
}
