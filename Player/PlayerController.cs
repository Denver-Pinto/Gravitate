using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float acceleration;
    public float maxSpeed;
    private Rigidbody rigidBody; //component attached to the player
    private KeyCode[] inputKeys; //designated keys
    private Vector3[] directionsForKeys; //their respective directions
    // Use this for initialization
    void Start () {
       // inputKeys = new KeyCode[] { KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow }; 
        //directionsForKeys = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right }; //w->forward a->left s->back d->left
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /* for (int i = 0; i < inputKeys.Length; i++)
         {
             var key = inputKeys[i];
             //check whether the pressed key was one of the designated ones
             if (Input.GetKey(key) && this!=null)
             {
                 //creating a direction vector 
                 Vector3 movement = directionsForKeys[i] * acceleration * Time.deltaTime;
                 movePlayer(movement);

             }
         }*/
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rigidBody.AddForce(0, 0, maxSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rigidBody.AddForce(-(maxSpeed * Time.deltaTime), 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rigidBody.AddForce(0, 0, -(maxSpeed * Time.deltaTime), ForceMode.VelocityChange);
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rigidBody.AddForce(maxSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    void movePlayer(Vector3 movement)
    {
        if (rigidBody.velocity.magnitude * acceleration > maxSpeed) //check if greater than maxspeed
        {
            rigidBody.AddForce(movement * -1);//apply resisting force
        }
        else
        {
            rigidBody.AddForce(movement);//apply normal  force
        }
    }
}
