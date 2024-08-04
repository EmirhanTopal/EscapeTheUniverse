using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Untagged"))
            Debug.Log(collision.gameObject.name + " collided");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Untagged"))
        {
            Debug.Log(other.gameObject.name + " triggered");
        }
    }
    
}
