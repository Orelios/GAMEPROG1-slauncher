using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerText;
    private float time = 0;
    [HideInInspector]
    public int endPoint = 0; 
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    public void timerCount()
    {
        time += Time.deltaTime;
        timerText.text = "Time: " + time.ToString("0.00");
        if (endPoint == 1)
        {
            enabled = false;
        }
    }

    void Update()
    {
        timerCount();
    }

}
