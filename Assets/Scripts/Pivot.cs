using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public Player myPlayer;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform Slauncher;
    public bool canFire;
    public float cooldown;
    private float cooldownTimer;

    void Start()
    {
        canFire = true;
    }

    private void FixedUpdate()
    {
        RotateSlauncher();

        if (!canFire)
        {
            UpdateCooldownTimer();
        }

        else if (myPlayer.health >= 2.0f && Input.GetMouseButton(0))
        {
            ShootSlime();
        }
    }

    void RotateSlauncher()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90)
        {
            if (myPlayer.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if (myPlayer.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
        }
    }

    void ShootSlime()
    {
        Instantiate(bullet, Slauncher.position, Quaternion.identity);
        myPlayer.health -= 1.0f;
        canFire = false;
    }

    void UpdateCooldownTimer()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer > cooldown)
        {
            canFire = true;
            cooldownTimer = 0;
        }
    }
}