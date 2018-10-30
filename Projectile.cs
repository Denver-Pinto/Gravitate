
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;
    Vector3 shootDirection;
    void Start()
    {
    }
    void FixedUpdate()
    {
        this.transform.Translate(shootDirection * speed, Space.World);
    }
    public void FireProjectile(Ray shootRay)
    {
        this.shootDirection = shootRay.direction;
        this.transform.position = shootRay.origin;
        rotateInShootDirection();
    }
    void OnCollisionEnter(Collision col)
    {
        Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(damage);//reduce health of enemy on impact
            Destroy(this.gameObject);// its work is done
        }
        // Destroy(this.gameObject);// its work is done
        else if(col.collider.gameObject.tag=="wall")
        {
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
            player.health -= 1;
            player.checkHealth();
            player.DisplayHealth();
            Destroy(this.gameObject);
        }
    }
    void rotateInShootDirection()
    {
        Vector3 newRotation = Vector3.RotateTowards(transform.forward, shootDirection, 0.01f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newRotation);
    }

}
