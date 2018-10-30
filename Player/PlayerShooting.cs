using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShooting : MonoBehaviour
{
    // Use this for initialization
    public Projectile projectilePrefab;//the projectile we created
    public LayerMask mask;//to filter the gameObjects
    void Start()
    {
    }
    void shoot(RaycastHit hit)
    {
        // initialize prefab 
        var projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();
        // mouse click=hit that is parallel to the ground
        var pointAboveFloor = hit.point + new Vector3(0, this.transform.position.y, 0);
        // calculating direction vector
        var direction = pointAboveFloor - transform.position;
        //creating a raw using players position and calculated direction
        var shootRay = new Ray(this.transform.position, direction);
        // makesurethat the projectile leaves the projector
        Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent<Collider>());
        // assign trajectory
        projectile.FireProjectile(shootRay);
    }
    //user click trigger
    void raycastOnMouseClick()
    {
        RaycastHit hit;
        Ray rayToFloor = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayToFloor, out hit, 100.0f, mask, QueryTriggerInteraction.Collide))
        {
            shoot(hit);
        }
    }
    // check if user presses the mouse
    void Update()
    {
        bool mouseButtonDown = Input.GetMouseButtonDown(0);
        if (mouseButtonDown)
        {
            raycastOnMouseClick();
        }
    }
}