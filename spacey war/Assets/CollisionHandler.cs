using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour

{  
    [SerializeField] ParticleSystem ExplosionVFX;
      void OnTriggerEnter(Collider other) 
    {
        Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}"); 
        CrashSequence();   
    }

    void CrashSequence()
    {
        GetComponent<PlayerControls>().enabled = false;
        Explosion();
        Invoke("ReloadScene", 1);
    }

    void Explosion()
    {
        ExplosionVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
// implement collision
// log output on collision
