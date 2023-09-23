using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killing : MonoBehaviour
{
    public enemyWalking ew;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        ew = enemy.GetComponent<enemyWalking>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            killEdward();
        }
    }

    public void killEdward()
    {
        Debug.Log("player collided");
        GameObject o = Instantiate(ew.corpse);
        o.transform.position = ew.player.transform.position;

        ew.player.transform.position = ew.spawnPosition[ew.spawnCount].transform.position;

    }
}
