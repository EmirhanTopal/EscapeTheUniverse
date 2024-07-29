using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        float horizontalThroughX = movement.ReadValue<Vector2>().x;
        float verticalThroughY = movement.ReadValue<Vector2>().y;


        // float horizontalThrough = Input.GetAxis("Horizontal");
        Debug.Log(horizontalThroughX);
        //
        // float verticalThrough = Input.GetAxis("Vertical");
        Debug.Log(verticalThroughY);
    }
}
