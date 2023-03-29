using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlime : MonoBehaviour
{
    private GameObject player; //Used to search fo the player
    private Rigidbody2D rb; //Used for physics
    public float speed = 3.0f; //Determines how fast the bullet travels
    public float lifeTime = 15.0f; //Determines how long the bullet last

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, lifeTime); //Destroy the object

        rb.velocity = new Vector2(0, -1).normalized * speed;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && collider.GetComponent<Player>().canPickUp == true)
        {
            Destroy(this.gameObject);
        }

    }
}
