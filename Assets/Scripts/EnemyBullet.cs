using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 3.0f; //Determines how fast the bullet travels
    public float lifeTime = 3.0f; //Determines how long the bullet last
    public float damage = 1.0f; //Determines how much damage the bullet has

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime); //Destroy the object
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.GetComponent<Player>().health -= damage;
            Destroy(this.gameObject);
        }
    }
}
