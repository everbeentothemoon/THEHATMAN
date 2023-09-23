using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulum : MonoBehaviour
{
    public float amplitude = 20f; 
    public float speed = 1f;  

    private Vector3 pivotPosition;

    private void Start()
    {
        pivotPosition = transform.position;
    }

    private void Update()
    {
        float angle = amplitude * Mathf.Sin(speed * Time.time);

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        transform.position = pivotPosition;
    }
}
