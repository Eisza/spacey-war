using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject EnemyExplosion;
    [SerializeField] Transform IARuntime;

    [SerializeField] int killScore = 20;
    [SerializeField] int health = 3;
    ScoreBoard scoreBoard;
    
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        health -= 1;
        ProcessScore(1);

        if (health <= 0)
        {
            ProcessScore(killScore);
            KillEnemy();
        }
    }

    void ProcessScore(int amount)
    {
        scoreBoard.AddScore(amount);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(EnemyExplosion, this.transform.position, Quaternion.identity);
        vfx.transform.parent = IARuntime;

        Destroy(gameObject);
    }
}
