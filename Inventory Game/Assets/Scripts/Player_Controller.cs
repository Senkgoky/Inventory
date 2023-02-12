using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed=10f;
    
    public float horizontalInput;
    public float verticalInput;
    public Vector3 movementDirection;
    //The character controller has priority over the rigidbody, so you have to force the direction of the character to go down
    public float forceDownCharacter=-5f; 

    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movementDirection = new Vector3(horizontalInput, forceDownCharacter, verticalInput);
        characterController.Move(movementDirection * Time.deltaTime * speed);
    }
}
