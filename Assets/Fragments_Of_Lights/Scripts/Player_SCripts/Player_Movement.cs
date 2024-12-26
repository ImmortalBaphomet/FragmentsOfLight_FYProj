using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    private CharacterController characterController;
    private Vector3 moveDirection;
    private Quaternion targetRotation;

    public Animator playerAnim;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        targetRotation = transform.rotation; // Set the initial rotation
    }

    private void Update()
    {
        // Get horizontal and vertical input (A/D, W/S or Arrow Keys)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction and reset to zero if no input is given
        if (horizontalInput != 0 || verticalInput != 0)
        {
            moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized * moveSpeed;

            // Smooth rotation (flip) based on movement direction
            targetRotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0f, verticalInput));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            playerAnim.SetBool("Run",true);
        }
        else
        {
            moveDirection = Vector3.zero; // Stop moving when no input
            playerAnim.SetBool("Run", false);

        }

        // Apply movement
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
