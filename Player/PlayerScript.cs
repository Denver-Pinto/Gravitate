using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerScript : MonoBehaviour {
    public int health = 10;
    private int score;
    public Text Counttext;
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
    }
    public void UpdateScore()
    {
        score = score + 1;
        DisplayScore();

    }
    void DisplayScore()
    {
        Counttext.text = "Count: " + score.ToString();
    }
    // Update is called once per frame
    void Update () {
       
    }

    public static implicit operator GameObject(PlayerScript v)
    {
        throw new NotImplementedException();
    }
}
