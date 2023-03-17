using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player; //Used to search fo the player
    private Rigidbody2D rb; //Used for physics
    public float speed = 3.0f; //Determines how fast the bullet travels
    public float lifeTime = 3.0f; //Determines how long the bullet last
    public float damage = 1.0f; //Determines how much damage the bullet has

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, lifeTime); //Destroy the object
        player = GameObject.FindGameObjectWithTag("Player"); //Defines the tag of the player

        Vector3 direction = player.transform.position - transform.position; //Searches the player's position
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed; //Bullet goes straight to player
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && collider.GetComponent<Player>().damageAble == true)
        {
            collider.GetComponent<Player>().health -= damage;
            Destroy(this.gameObject);
        }

    }
}
