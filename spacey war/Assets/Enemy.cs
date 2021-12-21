using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject EnemyExplosion;
    [SerializeField] Transform IARuntime;
    ScoreBoard scoreBoard;
    
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    
    void OnParticleCollision(GameObject other)
    {
        ProcessScore();
        KillEnemy();
    }


    private void ProcessScore()
    {
        scoreBoard.AddScore(25);
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(EnemyExplosion, this.transform.position, Quaternion.identity);
        vfx.transform.parent = IARuntime;

        Destroy(gameObject);
    }
}
