using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject EnemyExplosion;
    [SerializeField] Transform IARuntime;
    // Start is called before the first frame update
    void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(EnemyExplosion, this.transform.position, Quaternion.identity);
        vfx.transform.parent = IARuntime;
        Destroy(gameObject);
    }
}
