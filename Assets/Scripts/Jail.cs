using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jail : MonoBehaviour
{
    public GameObject AllySlime;
    public float amtOfSlimes;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            Destroy(this.gameObject);
            Spawn();
        }
    }

    void Spawn()
    {
        for (float i = 0.0f; i < amtOfSlimes; i+= 1.0f)
        {
            Instantiate(AllySlime, transform.position, Quaternion.identity);
        }
    }
}
