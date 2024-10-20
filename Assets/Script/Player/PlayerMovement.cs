using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;    // Speed of the player
    public float gravity = -9.81f;  // Gravity effect
    public float jumpHeight = 2f;   // Jump height
    public Camera playerCamera;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is on the ground
        isGrounded = controller.isGrounded;

        // If the player is on the ground and pressing the jump key, jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        
        // Calculate movement direction based on camera orientation
        Vector3 moveDirection = playerCamera.transform.right * moveX + playerCamera.transform.forward * moveZ;
        moveDirection.y = 0; // Keep the movement on the horizontal plane
        moveDirection.Normalize(); // Normalize to ensure consistent speed

        // Move the player
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Move the player with gravity
        controller.Move(velocity * Time.deltaTime);

        // Rotate the player to face the camera's forward direction
        if (moveDirection.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}

