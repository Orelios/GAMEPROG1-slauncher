using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    private Vector3 direction;
    private Vector3 rotation;

    public float bulletSpeed;
    public float lifeTime;
    private int slaunchableLayerNum = 3;
    private int groundLayerNum = 6;

    public float fieldOfImpact;
    public float force;
    public LayerMask layer;
    public GameObject explosion;

    [SerializeField] private AudioSource explosionSoundEffect;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        ScaleExplosion();

        Destroy(this.gameObject, lifeTime);
        InitializeBullet();
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
            Destroy(this.gameObject, 0.3f);

            if (collider.gameObject.tag == "Slime")
            {
                Destroy(collider.gameObject);
            }
            if (collider.gameObject.tag == "Jail")
            {
                Destroy(collider.gameObject);
            }
        }
    }

    private void InitializeBullet()
    {
        GetDirection();
        rotation = transform.position - mousePos;
        rb.velocity = Get2DVelocity(bulletSpeed);

        // Rotate bullet
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void Explode()
    {
        try
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
        }
        catch
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0.0f, 0.0f);
        }

        explosion.SetActive(true);
        explosionSoundEffect.Play();

        // Launch gameObjects nearby
        var objectsNearby = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layer);

        foreach (var obj in objectsNearby)
        {
            Vector2 velocity = -(Get2DVelocity(force));
            obj.GetComponent<Rigidbody2D>().AddForce(velocity);
        }
    }

    // [ COMPUTATIONS ] ============================================================================
    private void ScaleExplosion()
    {
        explosion.transform.localScale += new Vector3(fieldOfImpact * 1, fieldOfImpact * 1, 0);
    }

    private void GetDirection()
    {
        direction = mousePos - transform.position;
    }

    private Vector2 Get2DVelocity(float speed)
    {
        Vector2 velocity = new Vector2(direction.x, direction.y).normalized * speed;
        return velocity;
    }

    /* Note: Doesn't show accurate range
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }
    */
}
