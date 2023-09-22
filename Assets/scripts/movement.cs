using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;

    public float rotationSpeed = 180f;
    private Quaternion targetRotation = Quaternion.identity;

    private bool isGrounded;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get horizontal input (-1 for left, 1 for right)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the player horizontally
        Move(horizontalInput);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Check for jump input
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Check for "Z" key press
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Check if the GameObject is 2D or 3D
            if (gameObject.GetComponent<SpriteRenderer>() != null) // For 2D (has SpriteRenderer component)
            {
                Rotate2DToZero();
            }
            else // For 3D (has MeshRenderer component)
            {
                Rotate3DToZero();
            }
        }

        transform.rotation = targetRotation;

    }

    private void Rotate2DToZero()
    {
        // Calculate the target rotation in degrees (in this case, 0 degrees)
        float targetRotation = 0f;

        // Get the current Z rotation of the GameObject
        float currentRotation = transform.eulerAngles.z;

        // Calculate the difference between the target rotation and the current rotation
        float rotationDifference = targetRotation - currentRotation;

        // Ensure the rotation difference is within the range of -180 to 180 degrees
        if (rotationDifference > 180f)
        {
            rotationDifference -= 360f;
        }
        else if (rotationDifference < -180f)
        {
            rotationDifference += 360f;
        }

        // Rotate the GameObject towards the target rotation
        float rotationStep = rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, rotationDifference > 0f ? Mathf.Min(rotationStep, rotationDifference) : Mathf.Max(-rotationStep, rotationDifference));
    }

    private void Rotate3DToZero()
    {
        // Calculate the target rotation as Quaternion.identity (no rotation)
        Quaternion targetRotation = Quaternion.identity;

        // Interpolate the rotation towards the target using Slerp
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a gizmo to visualize the ground check circle
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void Move(float horizontalInput)
    {
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
}