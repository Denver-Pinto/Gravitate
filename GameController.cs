using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour {
    public Spawner enemyProducer;
    public GameObject playerPrefab;
    // Use this for initialization
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        player.onPlayerDeath += onPlayerDeath;
        
    }

    void onPlayerDeath(PlayerScript player)
    {
        enemyProducer.SpawnEnemies(false);
        Destroy(player.gameObject);
      
                Invoke("restartGame",5);
   
      
    }
    void restartGame()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
          Destroy(enemy);
       }
        var playerObject = Instantiate(playerPrefab, new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;
        var cameraRig = Camera.main.GetComponent<CameraController>();
        cameraRig.player = playerObject;
        enemyProducer.SpawnEnemies(true);
        playerObject.GetComponent<PlayerScript>().onPlayerDeath += onPlayerDeath;
    }

}
