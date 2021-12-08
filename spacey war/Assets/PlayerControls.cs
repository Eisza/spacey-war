using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("How fast ship moves based on input")]
    [SerializeField] float controlSpeed = 1f;
    [Tooltip("Ship pitch based on position to keep aim in center of screen")]
    [SerializeField] float pitchOfPositionFactor = 0.33f;
    [Tooltip("Ship sway while moving")]
    [SerializeField] float pitchOfControlFactor = -20f;
    [Tooltip("Ship sway while moving")]
    [SerializeField] float rollFactor = -60f;
    [Tooltip("Ship yaw based on position to keep aim in center of screen")]
    [SerializeField] float yawOfPositionFactor = -0.33f;
    [Tooltip("Laser Controls")]
    [SerializeField] GameObject[] lasers;

    float xThrow;
    float yThrow;
    void Update()
    {
        ProcessTransformation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {   
        float positionPitch = transform.localPosition.y * pitchOfPositionFactor;
        float controlPitch = yThrow * pitchOfControlFactor;
        float pitch = positionPitch + controlPitch;

        float yaw = transform.localPosition.x * yawOfPositionFactor;

        
        float roll = xThrow * rollFactor;


         Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);

        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, 1);
    }

    void ProcessTransformation()
    {
        xThrow = Input.GetAxis("Horizontal") * Time.deltaTime * controlSpeed;
        float xOffset = transform.localPosition.x + xThrow;
        float xPos = Mathf.Clamp(xOffset, -11, 11);

        yThrow = Input.GetAxis("Vertical") * Time.deltaTime * controlSpeed;
        float yOffset = transform.localPosition.y + yThrow;
        float yPos = Mathf.Clamp(yOffset, -7, 7);


        transform.localPosition = new Vector3(
            xPos,
            yPos,
            transform.localPosition.z
        );
    }

    void ProcessFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }

    }

    void SetLasersActive( bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var laserEmission = laser.GetComponent<ParticleSystem>().emission;
            laserEmission.enabled = isActive;
        };
    }
}
