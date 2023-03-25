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

    public float fieldOfImpact;
    public float force;
    public LayerMask layer;

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
        if (collider.gameObject.tag == "Player")
        {
            return;
        }

        if (collider.gameObject.layer == groundLayerNum
            || collider.gameObject.layer == slaunchableLayerNum)
        {
            Explode();
            Destroy(this.gameObject);
        }
    }

    private void Explode()
    {
        var objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layer);

        foreach (var obj in objects)
        {
            Vector2 velocity = (obj.transform.position - transform.position).normalized * force;
            obj.GetComponent<Rigidbody2D>().AddForce(velocity);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }

}
