using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
    public Player player;
    public GameObject slime;
    public float splitForce = 5.0f;
    private Rigidbody2D rb;
    Vector2 v;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            //only allows player to Split when health >= 3 
            if(player.health >= 3.0f)
            {
                //prevents player from immediately picking up newly split slime
                //Player script has code for cooldown to pick up slimes
                player.cooldownTimerPickUp = player.cooldownPickUp;
                player.canPickUp = false;
                //instantiates slime and pushes player up
                Instantiate(slime, transform.position, Quaternion.identity);
                v = rb.velocity;
                if(v.y < 0.0f)
                {
                    v.y = 0.0f;
                    rb.velocity = v;
                }
                rb.AddForce(new Vector2(0.0f, splitForce), ForceMode2D.Impulse);
                player.health -= 1.0f;
            }
            else
            {
                Debug.Log("Insufficient health");
            }
        }
    }
}
