using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public string playerTag = "Player"; 
    public Transform destinationTransform;
    public enemyWalking ew;
    public GameObject enemy;

    public void Start()
    {
        ew = enemy.GetComponent<enemyWalking>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            other.transform.position = destinationTransform.position;
            ew.spawnCount++;
        }
    }
}
