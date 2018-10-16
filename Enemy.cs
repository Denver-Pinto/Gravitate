using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // Use this for initialization
    public float moveSpeed;
    public int health; 
    public int damage;
    public Transform targetTransform;
    private PlayerScript p;
    void Start () {
         p = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }
    void FixedUpdate()
    {
        if (targetTransform != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetTransform.transform.position, Time.deltaTime * moveSpeed);
        }
    }

    public void TakeDamage(int damage)//called when player shoots
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            
            p.UpdateScore();
        }
    }

    public void Attack(PlayerScript player) //called when player collides with me
    {
        player.health -= this.damage;
        Destroy(this.gameObject);
        player.UpdateScore();
        player.DisplayHealth();
    }
    public void Initialize(Transform target, float moveSpeed, int health)
    {
        this.targetTransform = target;
        this.moveSpeed = moveSpeed;
        this.health = health;
    }


}
