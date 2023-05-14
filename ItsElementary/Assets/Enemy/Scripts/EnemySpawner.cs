using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    private float timeSinceLastSpawn;
    private float randomTimeInterval;
    public int startInterval = 10;
    public int endInterval = 30;
    public int maxEnemies = 5;
    public bool tutorial = false;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawn = Time.realtimeSinceStartup;
        RandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        spawn();
    }

    void RandomTime()
    {
        randomTimeInterval = Random.Range(startInterval,endInterval);
    }

    void spawn()
    {
        if (Time.realtimeSinceStartup - timeSinceLastSpawn > randomTimeInterval && GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            if (GameObject.FindGameObjectsWithTag("Boss").Length > 0 || tutorial)
            {
                GameObject enemyClone = Instantiate(enemy);
                enemyClone.SetActive(true);
                enemyClone.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 0));
                timeSinceLastSpawn = Time.realtimeSinceStartup;
                RandomTime();
            }
            
        }
    }
}
