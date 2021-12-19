using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour

{  

      void OnTriggerEnter(Collider other) 
    {
        Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}"); 
        CrashSequence();   
    }

    void CrashSequence()
    {
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadScene",1);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
// implement collision
// log output on collision
