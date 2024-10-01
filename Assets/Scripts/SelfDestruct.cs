using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public void Update()
    {
        if (transform.GetComponentInChildren<ParticleSystem>())
        {
            GameObject obj = transform.GetComponentInChildren<ParticleSystem>().gameObject;
            Destroy(obj, 3f);
        }
    }
}
