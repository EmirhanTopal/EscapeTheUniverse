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
    }

    private void MovementSpaceShip()
    {
        //LocalPosition bir nesnenin kendi parent'ına göre konumunu ifade eder.
        
        float horizontalThroughX = movement.ReadValue<Vector2>().x;
        float verticalThroughY = movement.ReadValue<Vector2>().y;

        float xOffset = xSpeed * horizontalThroughX * Time.deltaTime;
        float newXPos = transform.localPosition.x + xOffset;
        
        float yOffset = ySpeed * verticalThroughY * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;
        
        //transform.localPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);  *** yanlış *** normal pozisyon
        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }
}
