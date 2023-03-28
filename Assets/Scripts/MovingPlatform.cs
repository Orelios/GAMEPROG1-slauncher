using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    private int currentWayPoint = 0;

    [SerializeField] private float platformSpeed = 2f;

    public Player player; 
    void Update()
    {
        if (Vector2.Distance(wayPoints[currentWayPoint].transform.position,
            transform.position) < 0.1f)
        {
            currentWayPoint++; 
            if(currentWayPoint >= wayPoints.Length)
            {
                currentWayPoint = 0; 
            }
        }
        transform.position = Vector2.MoveTowards(transform.position,
            wayPoints[currentWayPoint].transform.position, Time.deltaTime * platformSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
            player.resizeTrue = 0; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
            player.resizeTrue = 1;
        }
    }
}
