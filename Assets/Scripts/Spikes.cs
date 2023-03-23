using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Player player;
    public float damage = 1.0f;
    public PlayerMovement playerMovement; //talks to movement script

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerMovement.KBCounter = playerMovement.KBTotalTime;//resets KBCounter to equal KBTotalTime
            if(collision.transform.position.x < transform.position.x)//if player is on the left, hit from right
            {
                playerMovement.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)//if player is on the right, hit from left
            {
                playerMovement.KnockFromRight = false;

            }
            player.health -= damage;
        }
    }
}
