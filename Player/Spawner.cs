using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour {
    // Use this for initialization
    public bool shouldSpawn; //t/f
    public Enemy[] enemyPrefabs; //choose from one of these
    public float[] moveSpeedRange;//range for the speed of the spawned enemy
    public int[] healthRange; //range forthe health of the spawned enemy
    private Bounds spawnArea;// the producer box in our scene
    private GameObject player;
    public void SpawnEnemies(bool shouldSpawn)
    {
        if (shouldSpawn)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        this.shouldSpawn = shouldSpawn;
    }
    void Start()
    {
        spawnArea = this.GetComponent<BoxCollider>().bounds;
        SpawnEnemies(shouldSpawn);
        InvokeRepeating("spawnEnemy", 0.5f, 6.0f);//calls it every 2 seconds
    }

    Vector3 randomSpawnPosition()//getting a random position in the box
    {
        float x = Random.Range(spawnArea.min.x, spawnArea.max.x);
        float z = Random.Range(spawnArea.min.z, spawnArea.max.z);
        float y = 0.5f;
        return new Vector3(x, y, z);
    }
    void spawnEnemy()
    {
        if (shouldSpawn == false || player == null)//only spawn when required
        {
            return;
        }

        int index = Random.Range(0, enemyPrefabs.Length);//getting a random index to choose between one of the prefabs
        var newEnemy = Instantiate(enemyPrefabs[index], randomSpawnPosition(), Quaternion.identity) as Enemy;
        newEnemy.Initialize(player.transform,
            Random.Range(moveSpeedRange[0], moveSpeedRange[1]),
            Random.Range(healthRange[0], healthRange[1]));//initializing the enemy with random speed and health
    }
}
