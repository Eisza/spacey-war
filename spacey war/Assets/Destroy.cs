using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] float timer = 3f;
    void Start()
    {
        Destroy(this.gameObject,timer);
    }

}
