using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemiesToSpawn;
    public List<Enemy> SpawnedEnemies;

    public GameObject player;

    public float SpawnInterval = 2f;

    private float lastSpawnTime = 0;


    void Update()
    {

        if (lastSpawnTime + SpawnInterval < Time.time)
        {
            SpawnEnemy();
        }
    }


    public void SpawnEnemy()
    {
        if (player == null)
        {
            // assume the player is dead

            SpawnedEnemies.ForEach(enemy =>
            {
                enemy.target = null;
                enemy.GoToSleep();
            });


            return;
        }

        var enemyToSpawn = EnemiesToSpawn[Random.Range(0, EnemiesToSpawn.Count)];
        var enemyGo = Instantiate(enemyToSpawn, transform.position, transform.rotation);

        var enemy = enemyGo.GetComponent<Enemy>();
        enemy.target = player.gameObject;

        SpawnedEnemies.Add(enemy);
        lastSpawnTime = Time.time;
    }







}
