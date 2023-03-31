using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jail : MonoBehaviour
{
    public Player player;
    public AllySlime allySlime;//talks to ally slime script for knockback/movement
    public GameObject AllySlime;
    public float amtOfSlimes;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Destroy(this.gameObject);
            allySlime.KBCounter = allySlime.KBTotalTime;//resets KBCounter to equal KBTotalTime

            Spawn();
            if (collision.transform.position.x < transform.position.x)//if player hit object from left, hit from right
            {
                allySlime.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)//if player hit object from right, hit from left
            {
                allySlime.KnockFromRight = false;
            }
        }

        else if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(this.gameObject);
            allySlime.KBCounter = allySlime.KBTotalTime;//resets KBCounter to equal KBTotalTime

            Spawn();
            if (collision.transform.position.x < transform.position.x)//if player hit object from left, hit from right
            {
                allySlime.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)//if player hit object from right, hit from left
            {
                allySlime.KnockFromRight = false;
            }
        }
    }
    void Spawn()
    {
        for (float i = 0.0f; i < amtOfSlimes; i+= 1.0f)
        {
            Instantiate(AllySlime, transform.position, Quaternion.identity);
        }
    }
}
