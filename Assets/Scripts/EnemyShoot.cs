using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet;
    private float recharge = 0.0f;
    public float fireRate = 3.0f;

    // Update is called once per frame
    void Update()
    {
        //Get Key will cause multiple spawning since Update is being called multiple times per second depending on the framerate
        //To fix this, we can add a cooldown or fire rate of some sort...
        //For now, we will use GetKeyDown instead

        if (recharge > 0)
        {
            recharge -= Time.deltaTime;
        }


        if (recharge <= 0)
        {
            //Spawn a bullet
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
            recharge = fireRate;
        }
    }
}
