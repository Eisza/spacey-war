using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 1f;
    void Update()
    {
        float xThrow =Input.GetAxis("Horizontal") * Time.deltaTime * controlSpeed;
        float xOffset =  transform.localPosition.x + xThrow;
        float xPos = Mathf.Clamp(xOffset, -11, 11);
        
        float yThrow = Input.GetAxis("Vertical") * Time.deltaTime * controlSpeed;
        float yOffset =  transform.localPosition.y + yThrow;
        float yPos = Mathf.Clamp(yOffset, -7, 7);
        

        transform.localPosition = new Vector3 (
            xPos,
            yPos,
            transform.localPosition.z
        );
    }
}
