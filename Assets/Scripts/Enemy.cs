using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathParticle;
    [SerializeField] private GameObject hitParticle;
    [SerializeField] private Transform parent;

    private Weapons weapons;
    private ScoreboardManager scoreboardManager;

    [SerializeField] private int enemyHealth;
    private void Start()
    {
        scoreboardManager = GameObject.Find("ScoreBoardTMP").GetComponent<ScoreboardManager>();
        weapons = GameObject.Find("Weapons").GetComponent<Weapons>();
        
    }

    private void OnParticleCollision(GameObject other)
    {
        LaserDamage(other);
    }

    private void EnemyParticleExplosion()
    {
        GameObject parentObj = Instantiate(deathParticle, transform.position, quaternion.identity);
        parentObj.transform.parent = parent;
        Destroy(this.gameObject);
    }

    private void EnemyScoreBoardPoint()
    {
        scoreboardManager.ScoreBoard(15);
        //Debug.Log(scoreboardManager.score);
    }

    private void LaserDamage(GameObject other)
    {
        if (other.gameObject.CompareTag("lazer"))
        {
            enemyHealth -= weapons.laserDamage;
            LaserHitParticle(other);
            //Debug.Log(enemyHealth);
        }
        if (enemyHealth <= 0)
        {
            EnemyScoreBoardPoint();
            EnemyParticleExplosion();
        }
    }

    private void LaserHitParticle(GameObject other)
    {
        ParticleSystem particleSystem = other.GetComponent<ParticleSystem>();
        List<ParticleCollisionEvent> particleCollisionEvents = new List<ParticleCollisionEvent>();
        int numCollisionEvents = particleSystem.GetCollisionEvents(gameObject, particleCollisionEvents);
        Debug.Log(numCollisionEvents);
        if (numCollisionEvents > 0)
        {
            Vector3 hitPoint = particleCollisionEvents[0].intersection;
            GameObject laserHitParticle = Instantiate(hitParticle, hitPoint, quaternion.identity);
            laserHitParticle.transform.parent = parent;
        }
    }
}
