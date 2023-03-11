using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    Vector2 checkPointPos;
    public Player player; 

    void Start()
    {
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
           
            if (player.health == 0) //Basically this is the code that will be put into the obstacles 
            {
                player.health = player.maxHealth;
                transform.position = checkPointPos;
            }
        }
    }
}
