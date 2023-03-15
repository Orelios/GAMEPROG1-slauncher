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
    // Start is called before the first frame update
    void Start()
    {
        cooldownTimerPickUp = cooldownPickUp;
    }

    // Update is called once per frame
    void Update()
    {
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
        if(cooldownTimerPickUp <= 0.0f)
        {
            canPickUp = true;
        }
        PlayerResize();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + "has stayed on trigger");
        if(other.gameObject.tag == "Slime" && canPickUp == true)
        {
            health += 1.0f;
            Destroy(other.gameObject);
            cooldownTimerPickUp = cooldownPickUp;
            canPickUp = false;
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
