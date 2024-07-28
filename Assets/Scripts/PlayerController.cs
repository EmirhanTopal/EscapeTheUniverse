using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrough = Input.GetAxis("Horizontal");
        Debug.Log(horizontalThrough);
        
        float verticalThrough = Input.GetAxis("Vertical");
        Debug.Log(verticalThrough);
    }
}
