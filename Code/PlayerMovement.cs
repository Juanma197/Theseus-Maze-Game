public class PlayerMovement : MonoBehaviour
{
//Variables
[SerializeField] private float moveSpeed;
[SerializeField] private float walkSpeed;

private Vector3 moveDirection;
private Vector3 velocity;

[SerializeField] private bool isGrounded;
[SerializeField] private float groundCheckDistance;
[SerializeField] private LayerMask groundMask;
[SerializeField] private float gravity;

//References
private CharacterController controller;

//initializes the reference to the CharacterController component.
//Which is the one used for moving the player.
private void Start()
{
controller = GetComponent<CharacterController>();

}

//Move method handles the player movement.
private void Update()
{
Move();

}

//It checks if the player is on the ground using a Physics.CheckSphere method.
//It checks if there is an object of the specified layer within the specified distance of the player's position.
private void Move()
{
isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

if(isGrounded && velocity.y < 0)
{
velocity.y = -2f;
}


//Gets input from the player in the x and z directions using the Input.GetAxis method.
float moveX = Input.GetAxis("Horizontal");

moveDirection = new Vector3(moveX, 0, 0);
moveDirection *= walkSpeed;

//Moves the player in the direction of the moveDirection vector multiplied by Time.deltaTime.
controller.Move(moveDirection * Time.deltaTime);

float moveZ = Input.GetAxis("Vertical");
moveDirection = new Vector3(0, 0.0f, moveZ);
moveDirection *= walkSpeed;

//Moves the player in the direction of the moveDirection vector multiplied by Time.deltaTime.
controller.Move(moveDirection * Time.deltaTime);

}

}

FPS Controller Class Code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An attribute that makes sure the game object this script is attached to has a CharacterController component.
[RequireComponent(typeof(CharacterController))]

