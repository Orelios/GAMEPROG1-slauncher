using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
    public Player player;
    public GameObject slime;
    // Start is called before the first frame update

    void Start()
    {
        
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
                Instantiate(slime, transform.position += new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
                player.health -= 1.0f;
            }
            else
            {
                Debug.Log("Insufficient health");
            }
        }
    }
}
