using UnityEngine;

public class killing : MonoBehaviour
{
    public enemyWalking ew;
    public GameObject enemy;
    private bool hasInstantiatedCorpse = false;

    void Start()
    {
        ew = enemy.GetComponent<enemyWalking>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasInstantiatedCorpse)
        {
            hasInstantiatedCorpse = true;
            killEdward();
        }
    }

    public void killEdward()
    {
        Debug.Log("player collided");
        GameObject o = Instantiate(ew.corpse);
        o.transform.position = ew.player.transform.position;

        ew.player.transform.position = ew.spawnPosition[ew.spawnCount].transform.position;

        hasInstantiatedCorpse = false;
    }
}
