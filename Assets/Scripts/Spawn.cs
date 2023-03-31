using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    Vector2 checkPointPos;
    public Player player;
    private Animator anim; //Used to reference parameters from the animator
    private Rigidbody2D rb;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource respawnSoundEffect;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        checkPointPos = transform.position;
    }

    public void updateCheckPoint(Vector2 position) //Triggered when player hits a checkpoint 
    {
        checkPointPos = position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //Player kill button since there are no obstacles yet
        {
            player.health = 0;
           
            if (player.health == 0) 
            {
                Die();
            }
        }

        if (player.health == 0)
        {
            Die();
        }
    }

    private void Respawn()
    {
        respawnSoundEffect.Play();
        player.health = player.maxHealth;
        transform.position = checkPointPos;
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetBool("death", false);
    }

    private void Die()
    {
        deathSoundEffect.Play();
        anim.SetBool("death", true);
        rb.bodyType = RigidbodyType2D.Static;
    }
 
}
