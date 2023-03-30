using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoves : MonoBehaviour
{
    private bool phaseOne = true;
    private bool phaseTwo = false;
    private bool phaseThree = false;

    [Header("Dave")]
    public float health = 15.0f;
    public float maxHealth = 15.0f;


    [Header("Bullets")]
    public GameObject bossBullet; //Dangerous Falling Bullets
    public GameObject fallingSlime; //Healing Falling Bullets
    public float bulletBarrage = 1;
    private float recharge = 0.0f;
    private float spawnTimeRate = 5.0f;

    [Header("Downward Bullet Spawner")]
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

    [Header("Left Bullet Spawner")]
    public GameObject leftBulletSpawner1;
    public GameObject leftBulletSpawner2;
    public GameObject leftBulletSpawner3;
    public GameObject leftBulletSpawner4;
    public GameObject leftBulletSpawner5;
    public GameObject leftBulletSpawner6;
    public GameObject leftBulletSpawner7;
    public GameObject leftBulletSpawner8;

    [Header("Right Bullet Spawner")]
    public GameObject rightBulletSpawner1;
    public GameObject rightBulletSpawner2;
    public GameObject rightBulletSpawner3;
    public GameObject rightBulletSpawner4;
    public GameObject rightBulletSpawner5;
    public GameObject rightBulletSpawner6;
    public GameObject rightBulletSpawner7;
    public GameObject rightBulletSpawner8;


    [Header("Summon")]
    public GameObject enemyMelee;
    public GameObject enemyRanged;
    public GameObject enemyTurret;
    private bool summonAble = true;
    public GameObject enemySpawner1;
    public GameObject enemySpawner2;
    public GameObject enemySpawner3;
    public GameObject enemySpawner4;
    public GameObject enemySpawner5;
    public GameObject enemySpawner6;


    [Header("Pool of Water")]
    public GameObject poolOfWater;
    private bool activateAbleWater = true;

    // Update is called once per frame
    void Update()
    {

        //Recharge Timer
        if (recharge > 0)
        {
            recharge -= Time.deltaTime;
        }


        //Phase One
        //Downward Bullets
        if (recharge <= 0 && phaseOne == true && bulletBarrage == 1 || recharge <= 0 && phaseOne == true && bulletBarrage == 4) // Spawn a barrage of bullets on the upper left side
        {
            Instantiate(bossBullet, bulletSpawner1.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner2.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner3.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner4.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner5.transform.position, Quaternion.identity);
            recharge = spawnTimeRate;
            bulletBarrage++;
        }

        if (recharge <= 0 && phaseOne == true && bulletBarrage == 2 || recharge <= 0 && phaseOne == true && bulletBarrage == 5) // Spawn a barrage of bullets on the upper right side
        {
            Instantiate(bossBullet, bulletSpawner6.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner7.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner8.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner9.transform.position, Quaternion.identity);
            Instantiate(bossBullet, bulletSpawner10.transform.position, Quaternion.identity);
            recharge = spawnTimeRate;
            bulletBarrage++;
        }

        //Left Bullets
        if (recharge <= 0 && phaseOne == true && bulletBarrage == 7) // Spawn a barrage of bullets on the upper left side
        {
            Instantiate(bossBullet, leftBulletSpawner1.transform.position, Quaternion.identity);
            Instantiate(bossBullet, leftBulletSpawner2.transform.position, Quaternion.identity);
            Instantiate(bossBullet, leftBulletSpawner3.transform.position, Quaternion.identity);
            Instantiate(bossBullet, leftBulletSpawner4.transform.position, Quaternion.identity);
            recharge = spawnTimeRate;
            bulletBarrage++;
        }

        if (recharge <= 0 && phaseOne == true && bulletBarrage == 8) // Spawn a barrage of bullets on the upper right side
        {
            Instantiate(bossBullet, leftBulletSpawner5.transform.position, Quaternion.identity);
            Instantiate(bossBullet, leftBulletSpawner6.transform.position, Quaternion.identity);
            Instantiate(bossBullet, leftBulletSpawner7.transform.position, Quaternion.identity);
            Instantiate(bossBullet, leftBulletSpawner8.transform.position, Quaternion.identity);
            recharge = spawnTimeRate;
            bulletBarrage++;
        }

        //Right Bullets
        if (recharge <= 0 && phaseOne == true && bulletBarrage == 10) // Spawn a barrage of bullets on the upper left side
        {
            Instantiate(bossBullet, rightBulletSpawner1.transform.position, Quaternion.identity);
            Instantiate(bossBullet, rightBulletSpawner2.transform.position, Quaternion.identity);
            Instantiate(bossBullet, rightBulletSpawner3.transform.position, Quaternion.identity);
            Instantiate(bossBullet, rightBulletSpawner4.transform.position, Quaternion.identity);
            recharge = spawnTimeRate;
            bulletBarrage++;
        }

        if (recharge <= 0 && phaseOne == true && bulletBarrage == 11) // Spawn a barrage of bullets on the upper right side
        {
            Instantiate(bossBullet, rightBulletSpawner5.transform.position, Quaternion.identity);
            Instantiate(bossBullet, rightBulletSpawner6.transform.position, Quaternion.identity);
            Instantiate(bossBullet, rightBulletSpawner7.transform.position, Quaternion.identity);
            Instantiate(bossBullet, rightBulletSpawner8.transform.position, Quaternion.identity);
            recharge = spawnTimeRate;
            bulletBarrage++;
        }


        //Healing Slime
        if (recharge <= 0 && phaseOne == true && bulletBarrage == 3 || recharge <= 0 && phaseOne == true && bulletBarrage == 9) // Spawn a barrage of falling healing slimes on the upper left side
        {
            Instantiate(fallingSlime, bulletSpawner1.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner2.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner3.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner4.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner5.transform.position, Quaternion.identity);
            recharge = spawnTimeRate;
            bulletBarrage++;
        }

        if (recharge <= 0 && phaseOne == true && bulletBarrage == 6 || recharge <= 0 && phaseOne == true && bulletBarrage == 12) // Spawn a barrage of falling healing slimes on the upper right side
        {
            Instantiate(fallingSlime, bulletSpawner6.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner7.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner8.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner9.transform.position, Quaternion.identity);
            Instantiate(fallingSlime, bulletSpawner10.transform.position, Quaternion.identity);
            recharge = spawnTimeRate;
            bulletBarrage++;
        }

        if (bulletBarrage >= 12)
        {
            bulletBarrage = 1;
        }

        //Phase Two

        if (health <= 10)
        {
            phaseTwo = true;
        }

        if(phaseTwo == true && summonAble == true) //Summons mobs after taking a certain amount of damage
        {
            Instantiate(enemyMelee, enemySpawner1.transform.position, Quaternion.identity);
            Instantiate(enemyMelee, enemySpawner2.transform.position, Quaternion.identity);
            Instantiate(enemyTurret, enemySpawner3.transform.position, Quaternion.identity);
            Instantiate(enemyTurret, enemySpawner4.transform.position, Quaternion.identity);
            Instantiate(enemyTurret, enemySpawner5.transform.position, Quaternion.identity);
            Instantiate(enemyTurret, enemySpawner6.transform.position, Quaternion.identity);
            recharge = spawnTimeRate;
            summonAble = false;
        }

        //Phase Three

        if (health <= 5)
        {
            phaseThree = true;
        }

        if (phaseThree == true && activateAbleWater == true)
        {
            poolOfWater.SetActive(true);
            activateAbleWater = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //Checks if it gets hit by the player bullet
    {
        if (other.tag == "PlayerBullet") 
        {
            health -= 1.0f;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
