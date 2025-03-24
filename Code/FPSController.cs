public class FPSController : MonoBehaviour
{
//Variables
public Camera playerCamera;
public float walkSpeed = 5f;
public float runSpeed = 10f;
public float jumpPower = 5f;
public float gravity = 10f;


public float lookSpeed = 2f;
public float lookXLimit = 90f;

Vector3 moveDirection = Vector3.zero;
float rotationX = 0;

public bool canMove = true;

CharacterController characterController;

// Start is called before the first frame update
// It Initializes characterController and sets the mouse cursor to be locked and invisible.
void Start()
{
characterController = GetComponent<CharacterController>();
Cursor.lockState = CursorLockMode.Locked;
Cursor.visible = false;
}

// Update is called once per frame.
//Contains the main logic of the FPS controller.
void Update()
{
//Calculates the forward and right vectors relative to the player's rotation.
#region Handles Movement
Vector3 forward = transform.TransformDirection(Vector3.forward);
Vector3 right = transform.TransformDirection(Vector3.right);

//Press Left Shift to run
bool isRunning = Input.GetKey(KeyCode.LeftShift);
float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
float movementDirectionY = moveDirection.y;
//Calculates the current speed of the player in the x and y directions.
moveDirection = (forward * curSpeedX) + (right * curSpeedY);

#endregion

//Checks if the jump button is pressed and the player is on the ground.
#region Handles Jumping

//If both conditions are true, moveDirection.y is set to jumpPower.
if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
{
moveDirection.y = jumpPower;
}
//Otherwise, the y velocity of the player is preserved.
else
{
moveDirection.y = movementDirectionY;
}

//It checks if the player is in the air.
//If true, moveDirection.y is decreased by gravity multiplied by Time.deltaTime to simulate gravity.
if (!characterController.isGrounded)
{
moveDirection.y -= gravity * Time.deltaTime;
}

#endregion

//It moves the player in the direction and with the speed calculated earlier.
#region Handles Rotation
characterController.Move(moveDirection * Time.deltaTime);

if (canMove)
{
//rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
//rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
//Rotates the camera up and down based on rotationX.
playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

//Rotates the player left and right based on the horizontal mouse movement.
transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

}

#endregion

}
}

On Collision Class Code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Namespaces provide access to Unity's game engine and scene management systems.

