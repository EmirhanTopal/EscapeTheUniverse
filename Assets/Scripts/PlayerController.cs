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

    [SerializeField] private float yawPositionFactor;

    [SerializeField] private float rollControlFactor;

    [SerializeField] private GameObject[] lasers;
     
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
        RotationSpaceShip();
        MovementSpaceShip();
        ControlLaser();
    }

    void RotationSpaceShip()
    {
        float pitch = transform.localPosition.y * pitchPositionValue + verticalThroughY * pitchControlFactor; // uçak aşağı yönde giderken uçağın burun aşağı bakar. x ROTASYON değeri bu duruma gönde değişir - x ekseni etrafında dönmek - (-) değer olacak
        float yaw = transform.localPosition.x * yawPositionFactor;
        float roll = horizontalThroughX * rollControlFactor; // uçak sağa veya sola giderken uçağın kanatları sağa veya sola yatar. z ROTASYON değeri bu duruma göre değişir - z ekseni etrafında dönmek - (-) değer olacak 
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
        Debug.Log(roll);
    }
    
    private void MovementSpaceShip()
    {
        //LocalPosition bir nesnenin kendi parent'ına göre konumunu ifade eder.
        
        // New Input System - values : -1 0 1
        // horizontalThroughX = movement.ReadValue<Vector2>().x;
        // verticalThroughY = movement.ReadValue<Vector2>().y;

        horizontalThroughX = Input.GetAxis("Horizontal");
        verticalThroughY = Input.GetAxis("Vertical");
        
        float xOffset = xSpeed * horizontalThroughX * Time.deltaTime;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXPos, -clampedXValue, clampedXValue);
        
        float yOffset = ySpeed * verticalThroughY * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos, -clampedYValue + 12, clampedYValue);
        
        //transform.localPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);  *** yanlış *** normal pozisyon
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ControlLaser()
    {
        if (Input.GetButton("Fire1"))
        {
            SetActiveLasers(true);
        }
        else
        {
            SetActiveLasers(false);
        }
        
    }

    void SetActiveLasers(bool isFireActive)
    {
        
        foreach (var laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFireActive;
        }
    }

    
}
