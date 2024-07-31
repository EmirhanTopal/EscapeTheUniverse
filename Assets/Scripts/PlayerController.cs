using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;

    [SerializeField] [Range(0, 50)] private float clampedXValue;
    [SerializeField] [Range(0, 50)] private float clampedYValue;

    private float horizontalThroughX, verticalThroughY;

    [SerializeField] private float pitchPositionValue;
    [SerializeField] private float pitchControlFactor;

    [SerializeField] private float yawRotationFactor;

    [SerializeField] private float rollControlFactor;
    
    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        MovementSpaceShip();
        RotationSpaceShip();
    }

    void RotationSpaceShip()
    {
        float pitch = transform.localPosition.y * pitchPositionValue + verticalThroughY * pitchControlFactor; // uçak aşağı yönde giderken uçağın burun aşağı bakar. x ROTASYON değeri bu duruma gönde değişir - x ekseni etrafında dönmek - (-) değer olacak
        float yaw = transform.localPosition.x * yawRotationFactor;
        float roll = horizontalThroughX * rollControlFactor; // uçak sağa veya sola giderken uçağın kanatları sağa veya sola yatar. z ROTASYON değeri bu duruma göre değişir - z ekseni etrafında dönmek - (-) değer olacak 
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
        Debug.Log(roll);
    }
    
    private void MovementSpaceShip()
    {
        //LocalPosition bir nesnenin kendi parent'ına göre konumunu ifade eder.
        
        horizontalThroughX = movement.ReadValue<Vector2>().x;
        verticalThroughY = movement.ReadValue<Vector2>().y;

        float xOffset = xSpeed * horizontalThroughX * Time.deltaTime;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXPos, -clampedXValue, clampedXValue);
        
        float yOffset = ySpeed * verticalThroughY * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos, -clampedYValue + 5, clampedYValue);
        
        //transform.localPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);  *** yanlış *** normal pozisyon
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
