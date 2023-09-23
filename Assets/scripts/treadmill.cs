using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treadmill : MonoBehaviour
{
    public float speed = 2.0f; 
    public Vector2 direction = Vector2.right;
    public movement m;

    public void Start()
    {
        m = GetComponent<movement>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = direction.normalized * speed;
        }
    }
}
