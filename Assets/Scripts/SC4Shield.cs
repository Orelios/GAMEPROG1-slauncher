using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC4Shield : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(player.sc4 >= 2)
            {
                Destroy(gameObject);
            }
        }
    }
}
