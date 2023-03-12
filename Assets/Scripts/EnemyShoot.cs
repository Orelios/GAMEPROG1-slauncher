using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet; //What the enemy will spawn/shoot out
    private float recharge = 0.0f; //Variable based on time
    public float fireRate = 3.0f; //Cooldown of shooting

    // Update is called once per frame
    void Update()
    {
        //The moment the enemy spawn, they will shoot
        if (recharge > 0)
        {
            recharge -= Time.deltaTime; //Reduces recharge's cooldown
        }


        if (recharge <= 0)
        {

            Instantiate(enemyBullet, transform.position, Quaternion.identity); //Spawn bullet
            recharge = fireRate; //Reset the variable
        }
    }
}
