using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemies : MonoBehaviour
{
    public GameObject enemyMelee;
    public GameObject enemyRanged;
    public GameObject enemyTurret;
    public GameObject spawner;
    private float recharge = 0.0f;
    private float spawnTimeRate = 15.0f;

    void Start()
    {
        
    }

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
            Instantiate(enemyMelee, spawner.transform.position, Quaternion.identity);
            recharge = spawnTimeRate; //Reset the variable
        }
    }
}
