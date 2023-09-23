using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public float jumpForce = 10f;   // The force applied when jumping
    public LayerMask groundLayer;   // Layer mask for detecting the ground
    public Transform groundCheck;   // A reference to a child GameObject used for ground detection
    public float groundCheckRadius = 0.1f; // Radius for ground detection

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the character is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump when the Jump button (e.g., Space) is pressed and the character is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Apply an upward force to make the character jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a gizmo to visualize the ground check circle
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
