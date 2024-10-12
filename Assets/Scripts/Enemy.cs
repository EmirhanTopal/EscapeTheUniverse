using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathParticle;
    [SerializeField] private GameObject hitParticle;
    [SerializeField] private int score;
    
    private GameObject parentGo;
    private Weapons weapons;
    private ScoreboardManager scoreboardManager;
    private Rigidbody rigidbody;
    private MusicManager musicManager;

    [SerializeField] AudioClip expEnemySfx;
    [SerializeField] private int enemyHealth;
    private void Start()
    {
        scoreboardManager = GameObject.Find("ScoreBoardTMP").GetComponent<ScoreboardManager>();
        weapons = GameObject.Find("Weapons").GetComponent<Weapons>();
        parentGo = GameObject.FindWithTag("ParentOBJ");
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        RigidbodyUses();
    }

    private void OnParticleCollision(GameObject other)
    {
        LaserDamage(other);
    }

    private void EnemySfx()
    {
        musicManager.MusicOn(expEnemySfx);
    }
    private void EnemyParticleExplosion()
    {
        GameObject parentObj = Instantiate(deathParticle, transform.position, quaternion.identity);
        //Yani parentGO nesnesinin altına parentObj nesnesini yerleştirmek için parentGO.
        //transform'u kullanmanız yeterlidir. Bu, parentObj'yi parentGO'nun bir alt nesnesi yapar.
        //Eğer parentGO.transform.parent yazarsanız, parentGO'nun ebeveyninin altına yerleştirmiş olursunuz. 
        parentObj.transform.parent = parentGo.transform;
        Destroy(this.gameObject);
    }
    
    private void EnemyScoreBoardPoint()
    {
        scoreboardManager.ScoreBoard(score);
        //Debug.Log(scoreboardManager.score);
    }

    private void RigidbodyUses()
    {
        rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    private void LaserDamage(GameObject other)
    {
        if (other.gameObject.CompareTag("lazer"))
        {
            enemyHealth -= weapons.laserDamage;
            LaserHitParticle(other);
            
        }
        if (enemyHealth <= 0)
        {
            EnemyScoreBoardPoint();
            EnemySfx();
            EnemyParticleExplosion();
        }
    }

    private void LaserHitParticle(GameObject other) //Laser particle ın değdiği noktayı bul ve orada instantiate et.
    {
        ParticleSystem particleSystem = other.GetComponent<ParticleSystem>();
        List<ParticleCollisionEvent> particleCollisionEvents = new List<ParticleCollisionEvent>();
        int numCollisionEvents = particleSystem.GetCollisionEvents(gameObject, particleCollisionEvents);
        Debug.Log(numCollisionEvents);
        if (numCollisionEvents > 0)
        {
            Vector3 hitPoint = particleCollisionEvents[0].intersection;
            GameObject laserHitParticle = Instantiate(hitParticle, hitPoint, quaternion.identity);
            laserHitParticle.transform.parent = parentGo.transform;
        }
    }
}
