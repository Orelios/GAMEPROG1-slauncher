using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Spawn spawn;

    private void Awake()
    {
        spawn = GameObject.FindGameObjectWithTag("Player").GetComponent<Spawn>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spawn.updateCheckPoint(transform.position); 
        }
    }

}
