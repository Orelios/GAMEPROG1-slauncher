using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitSlime : MonoBehaviour
{
    public float speed = -1.0f;
    public float max_Y = 5.5f;
    public float min_Y = -5.5f;
    public float max_X = 11.7f;
    public float min_X = -11.7f;
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //Since we are now using a RigidBody, we can move the gameObject by modifying its velocity
        rigidBody.velocity = new Vector2(0, speed);
        //Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //temp = slime position
        Vector3 temp = transform.position;
        //if slime goes out of bounds, destroy slime
        if (temp.x >= max_X || temp.x <= min_X || temp.y >= max_Y || temp.y <= min_Y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //if slime collides with Platform, slime is destroyed
        if(other.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }
        //Player script has the code to destroy slime when they collide
    }
}
