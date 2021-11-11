using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 1f;
    [SerializeField] float pitchOfPositionFactor = 0.33f;
    [SerializeField] float pitchOfControlFactor = -10f;
    [SerializeField] float rollFactor = -40f;
    [SerializeField] float yawOfPositionFactor = -0.33f;

    float xThrow;
    float yThrow;
    void Update()
    {
        ProcessTransformation();
        ProcessRotation();
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
}
