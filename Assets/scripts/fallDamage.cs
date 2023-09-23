using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallDamage : MonoBehaviour
{
    public float heightThreshold = 10f;
    private bool isAboveThreshold = false;
    private bool isDead = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.y > heightThreshold && !isDead)
        {
            isAboveThreshold = true;
        }
        else
        {
            isAboveThreshold = false;
        }

        if (isAboveThreshold && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement your player death logic here, for example:
        // - Play death animation
        // - Disable player control
        // - Display game over screen
        // - Reset the player position or reload the scene

        // Set the boolean to false
        isDead = true;
    }
}
