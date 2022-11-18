using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour
{
    [Header("Respawn")]
    public GameObject Enemy;
    float randX;
    Vector2 WhereToSpawn;
    public float SpawnRate;
    float nextSpawn = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + SpawnRate;
            randX = Random.Range(-2, 2f);
            WhereToSpawn = new Vector2(transform.position.x + randX, transform.position.y);
            Instantiate(Enemy, WhereToSpawn, Quaternion.identity);
        }
    }
}
