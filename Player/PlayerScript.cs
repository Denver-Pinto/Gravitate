using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerScript : MonoBehaviour {
    public int health = 20;
    private int score;
    public Text Counttext;
    public Text Healthtext;
    public Text gameover;
    public Text info;
    public event Action<PlayerScript> onPlayerDeath;
    void OnCollisionEnter(Collision col)
    {
        Enemy enemy = col.gameObject.GetComponent<Enemy>();
        
        if (enemy)
        {
            enemy.Attack(this);
            if (health <= 0)
            {
                if (onPlayerDeath != null)
                {
                    onPlayerDeath(this);
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
        score = 0;
        DisplayScore();
        gameover.text = "";
        info.text = "";
    }
    public void UpdateScore()
    {
        score = score + 1;
        DisplayScore();

    }
    public void RefreshScore()
    {
        score = 0;
        DisplayScore();
    }
    public void checkHealth()
    {
        if(health<=0)
        {
            if (onPlayerDeath != null)
            {
                onPlayerDeath(this);
            }
        }
    }
    void DisplayScore()
    {
        Counttext.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void RefreshHealth()
    {
        health = 20;
        DisplayHealth();
    }
    public void DisplayHealth()
    {
        Healthtext.text = "Health: " + health.ToString();
    }

    public static implicit operator GameObject(PlayerScript v)
    {
        throw new NotImplementedException();
    }
}
