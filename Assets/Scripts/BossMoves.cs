using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoves : MonoBehaviour
{
    private bool phaseOne = true;
    private bool phaseTwo = false;
    private bool phaseThree = false;

    [Header("Bullets")]
    public GameObject bossBullet; //Dangerous Falling Bullets
    public GameObject fallingSlime; //Healing Falling Bullets
    private float bulletBarrage = 1;
    public GameObject bulletSpawner1;
    public GameObject bulletSpawner2;
    public GameObject bulletSpawner3;
    public GameObject bulletSpawner4;
    public GameObject bulletSpawner5;
    public GameObject bulletSpawner6;
    public GameObject bulletSpawner7;
    public GameObject bulletSpawner8;
    public GameObject bulletSpawner9;
    public GameObject bulletSpawner10;

    [Header("Summon Enemies")]
    public GameObject enemyMelee;
    public GameObject enemyRanged;
    public GameObject enemyTurret;
    public GameObject enemySpawner1;
    public GameObject enemySpawner2;
    private float recharge = 0.0f;
    private float spawnTimeRate = 5.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Recharge Timer
        if (recharge > 0)
        {
            recharge -= Time.deltaTime;
        }


        //Phase One
        if (recharge <= 0 && phaseOne == true && bulletBarrage == 1 || recharge <= 0 && phaseOne == true && bulletBarrage == 4) // Spawn a barrage of bullets on the left side
        {
            Instantiate(bossBullet, bulletSpawner1.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner2.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner3.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner4.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner5.transform.position, Quaternion.identity);
            recharge = spawnTimeRate;
            bulletBarrage++;
        }

        if (recharge <= 0 && phaseOne == true && bulletBarrage == 2 || recharge <= 0 && phaseOne == true && bulletBarrage == 5) // Spawn a barrage of bullets on the right side
        {
            Instantiate(bossBullet, bulletSpawner6.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner7.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner8.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner9.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner10.transform.position, Quaternion.identity);
            recharge = spawnTimeRate;
            bulletBarrage++;
        }

        if (recharge <= 0 && phaseOne == true && bulletBarrage == 3) // Spawn a barrage of falling slimes on the left side
        {
            Instantiate(fallingSlime, bulletSpawner1.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner2.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner3.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner4.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner5.transform.position, Quaternion.identity);
            recharge = spawnTimeRate;
            bulletBarrage++;
        }

        if (recharge <= 0 && phaseOne == true && bulletBarrage == 6) // Spawn a barrage of falling slimes on the right side
        {
            Instantiate(fallingSlime, bulletSpawner6.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner7.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner8.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner9.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner10.transform.position, Quaternion.identity);
            recharge = spawnTimeRate;
            bulletBarrage = 1;
        }
    }
}
