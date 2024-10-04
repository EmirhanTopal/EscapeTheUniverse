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
        Debug.Log(scoreboardManager.score);
    }

    private void LaserDamage(GameObject other)
    {
        if (other.gameObject.CompareTag("lazer"))
        {
            enemyHealth -= weapons.laserDamage; // sorun yeni çıkan lazerin orda instantiate oluyor.
            GameObject parentObj = Instantiate(hitParticle, other.transform.position, quaternion.identity);
            parentObj.transform.parent = parent;
            Debug.Log(enemyHealth);
        }
        if (enemyHealth <= 0)
        {
            EnemyScoreBoardPoint();
            EnemyParticleExplosion();
        }
    }
}
