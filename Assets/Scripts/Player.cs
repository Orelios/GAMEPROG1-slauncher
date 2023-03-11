using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 12.0f;
    public float maxHealth = 12.0f;
    public bool canPickUp = false;
    public float cooldownPickUp = 1.0f;
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
}
