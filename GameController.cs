﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
    public Spawner enemyProducer;
    public GameObject playerPrefab;
    public Text Gameover;
    public Text info;
    // Use this for initialization
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        player.onPlayerDeath += onPlayerDeath;
        player.RefreshHealth();
        
    }

    void onPlayerDeath(PlayerScript player)
    {
        enemyProducer.SpawnEnemies(false);
        //Destroy(player.gameObject);
        Gameover.text = "Game Over !";
        info.text="Infinite missiles and a hell lot more of gravity!\nWill you survive?";

        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }
        Invoke("restartGame",7);
   
      
    }
    void restartGame()
    {
        //var playerObject = Instantiate(playerPrefab, new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;
        //var cameraRig = Camera.main.GetComponent<CameraController>();
        //cameraRig.player = playerObject;
        Gameover.text = "";
        info.text = "";
        enemyProducer.SpawnEnemies(true);
        // playerObject.GetComponent<PlayerScript>().onPlayerDeath += onPlayerDeath;
        // playerObject.GetComponent<PlayerScript>().Counttext = GameObject.Find("Counttext").GetComponent<Text>();
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        player.onPlayerDeath += onPlayerDeath;
        player.transform.position = new Vector3(0, 0.5f , 0);
        player.RefreshHealth();
        player.RefreshScore();
    }

}
