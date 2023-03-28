using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 1.0f;
    public float maxHealth = 1.0f;
    public float collisionDamage = 1.0f;
    public GameObject droppableSlime; 
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            health -= 1.0f;
        }

        if (health <= 0)
        {
            Instantiate(droppableSlime, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
