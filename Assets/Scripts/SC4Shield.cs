using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC4Shield : MonoBehaviour
{
    public Player player;
    [SerializeField] GameObject warp;

    void Start()
    {
        warp.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(player.sc4 >= 2)
            {
                Destroy(gameObject);
                warp.SetActive(true);
            }
        }
    }
}
