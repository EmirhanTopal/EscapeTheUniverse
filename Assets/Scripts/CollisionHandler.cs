using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem crashParticle;
    [SerializeField] private ParticleManager particleManager;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Untagged"))
        {
            Debug.Log(collision.gameObject.name + " collided");
            GetComponent<PlayerController>().enabled = false;
            ParticleManager.TriggerPlayParticle(crashParticle);
            particleManager.StopParticle();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            StartCoroutine(TimeHandler());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Untagged"))
        {
            Debug.Log(other.gameObject.name + " triggered");
            GetComponent<PlayerController>().enabled = false;
            ParticleManager.TriggerPlayParticle(crashParticle);
            particleManager.StopParticle();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            StartCoroutine(TimeHandler());
        }
    }
    
    IEnumerator TimeHandler()
    {
        yield return new WaitForSeconds(1);
        GetComponent<RestartController>().RestartScene();
    }
}
