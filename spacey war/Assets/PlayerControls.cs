using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 1f;
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal") * Time.deltaTime * controlSpeed;

        float yThrow = Input.GetAxis("Vertical") * Time.deltaTime * controlSpeed;

        transform.localPosition = new Vector3 (
            transform.localPosition.x + xThrow,
            transform.localPosition.y + yThrow,
            transform.localPosition.z
        );
    }
}
