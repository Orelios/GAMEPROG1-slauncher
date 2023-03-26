using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolOfWater : MonoBehaviour
{
    public Player player;
    public float delay;
    public float rate;
    public float damage = 1;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //The moment the enemy spawn, they will shoot
            if (delay > 0)
            {
                delay -= Time.deltaTime; //Reduces delay
            }


            if (delay <= 0)
            {
                player.health -= damage;
                delay = rate; //Reset the variable
            }
        }
    }
}
