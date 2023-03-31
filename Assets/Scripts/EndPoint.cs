using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class EndPoint : MonoBehaviour
{
    public Timer timer;
    public BossMoves bossMoves; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && bossMoves.health == 0)
        {
            timer.endPoint = 1;
            SceneManager.LoadScene("GameOverScreen"); 
        }
    }
}
