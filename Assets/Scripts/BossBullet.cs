using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private GameObject player; //Used to search for the player
    public GameObject bossMoves; //Used to search for the boss
    private Rigidbody2D rb; //Used for physics
    public float speed = 3.0f; //Determines how fast the bullet travels
    public float lifeTime = 15.0f; //Determines how long the bullet last

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, lifeTime);
        player = GameObject.FindGameObjectWithTag("Player"); //Defines the tag of the player
        bossMoves = GameObject.Find("Dave_Boss");

        if (bossMoves.GetComponent<BossMoves>().bulletBarrage == 4 || bossMoves.GetComponent<BossMoves>().bulletBarrage == 5)
        {
            Vector3 direction = player.transform.position - transform.position; //Searches the player's position
            rb.velocity = new Vector2(direction.x, direction.y).normalized * speed; //Bullet goes straight to player
        } 

        else if (bossMoves.GetComponent<BossMoves>().bulletBarrage == 7 || bossMoves.GetComponent<BossMoves>().bulletBarrage == 8)
        {
            rb.velocity = new Vector2(1, 0).normalized * speed;
        }

        else if (bossMoves.GetComponent<BossMoves>().bulletBarrage == 10 || bossMoves.GetComponent<BossMoves>().bulletBarrage == 11)
        {
            rb.velocity = new Vector2(-1, 0).normalized * speed;
        }

        else
        {
           rb.velocity = new Vector2(0, -1).normalized * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && collider.GetComponent<Player>().damageAble == true)
        {
            Destroy(this.gameObject);
        }
    }
}
