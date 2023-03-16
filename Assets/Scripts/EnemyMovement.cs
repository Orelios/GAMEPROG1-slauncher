using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f; //Used to determine the speed of the player
    public GameObject groundChecker; //Uses a seperate object within the enemy to make the collider
    Rigidbody2D rb;
    BoxCollider2D bc;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = groundChecker.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            rb.velocity = new Vector2(moveSpeed, 0f); //Move right
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0f); //Move left
        }
    }

    private bool IsFacingRight() //Checks if the character is facing right
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision) //If the collider doesn't collide with anything, it will flip
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
    }
}
