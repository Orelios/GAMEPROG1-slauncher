using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float bulletSpeed;
    public float lifeTime;
    private int slaunchableLayerNum = 3;
    private int groundLayerNum = 6;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Destroy(this.gameObject, lifeTime);
        InitializeBullet();
    }

    void InitializeBullet()
    {
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        // Velocity
        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;

        // Rotation
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == slaunchableLayerNum
            || collider.gameObject.layer == groundLayerNum)
        {
            Destroy(this.gameObject);
        }
    }
}
