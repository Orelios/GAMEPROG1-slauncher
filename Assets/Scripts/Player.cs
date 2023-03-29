using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 12.0f;
    public float maxHealth = 12.0f;
    public bool canPickUp = false;
    public float cooldownPickUp = 1.0f;
    public float largeHealth = 12.0f, mediumHealth = 8.0f, smallHealth = 4.0f;
    public float largeScale = 1.5f, mediumScale = 1.0f, smallScale = 0.5f;
    private float xScale, yScale, zScale = 0.0f;
    //cooldownTimerPickUp will be the value that decreases over time
    public float cooldownTimerPickUp;


    public float invulCooldown = 2.0f;
    public float invulCooldownTimer;
    // invulCooldownTimer will be the value that decreases over time
    public bool damageAble = true;
    // Checks if the player can be damaged


    // Start is called before the first frame update
    void Start()
    {
        cooldownTimerPickUp = cooldownPickUp;
        invulCooldownTimer = invulCooldown;
    }

    // Update is called once per frame
    void Update()
    {

        if (damageAble == false)
        {
            if (invulCooldownTimer > 0.0f)
            {
                invulCooldownTimer -= Time.deltaTime;
            }
        }

        if (invulCooldownTimer <= 0.0f)
        {
            damageAble = true;
        }

        //starts timer to allow pickup of slime
        if(canPickUp == false)
        {
            if (cooldownTimerPickUp > 0.0f)
            {
                cooldownTimerPickUp -= Time.deltaTime;
            }
            /*
            else
            {
                canPickUp = true;
            }
            */
        }

        if(cooldownTimerPickUp <= 0.0f && health < maxHealth)
        {
            canPickUp = true;
        }
        PlayerResize();
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + "has stayed on trigger");
        if(other.gameObject.tag == "Slime" && canPickUp == true || other.gameObject.tag == "DroppedSlime" && canPickUp == true)
        {
            if (other.gameObject.tag == "Slime")
            {
                health += 1.0f;
            }

            if (other.gameObject.tag == "DroppedSlime")
            {
                health += 2.0f;
            }

            if(health >= maxHealth) //prevents from overcapping
            {
                health = maxHealth;
            }
            Destroy(other.gameObject);
            cooldownTimerPickUp = cooldownPickUp;
            canPickUp = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //Used to make i-frames after taking damage from enemies
    {
        if (other.gameObject.tag == "Enemy" && damageAble == true || other.gameObject.tag == "EnemyBullet" && damageAble == true)
        {
            health -= 1;
            invulCooldownTimer = invulCooldown;
            damageAble = false;
        }
    }

    private void PlayerResize()
    {
        if(health >= 1 && health <= smallHealth)
        {
            xScale = smallScale;
            yScale = smallScale;
        }
        else if(health > smallHealth && health <= mediumHealth)
        {
            xScale = mediumScale;
            yScale = mediumScale;
        }
        else if(health > mediumHealth && health <= largeHealth)
        {
            xScale = largeScale;
            yScale = largeScale;
        }
        transform.localScale = new Vector3(xScale, yScale, zScale);
    }
}
