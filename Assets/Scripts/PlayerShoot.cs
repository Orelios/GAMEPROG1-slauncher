using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    public float cooldown;
    private float cooldownTimer;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canFire = true;
    }

    void Update()
    {
        RotateSlauncher();

        if (!canFire)
        {
            UpdateCooldownTimer();
        }

        if (canFire && Input.GetMouseButton(0))
        {
            ShootSlime();
        }
    }

    void RotateSlauncher()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    void ShootSlime()
    {
        Instantiate(bullet, bulletTransform.position, Quaternion.identity);
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
