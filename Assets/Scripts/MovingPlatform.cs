using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float platformSpeed = 1.5f; 
    Vector2 targetPos;

    void Start()
    {
        targetPos = start.position; 
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, start.position)<0.1f)
        {
            targetPos = end.position; 
        }

        if (Vector2.Distance(transform.position, end.position) < 0.1f)
        {
            targetPos = start.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos,
            platformSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
