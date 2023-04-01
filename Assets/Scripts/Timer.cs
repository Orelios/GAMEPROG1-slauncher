using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerText;
    [HideInInspector]
    static public float time = 0;
    static public float timePenalty = 0;
    private float tempPenalty = 0; 
    private float tempTime = 0; 
    public int endPoint = 0;
    private string minutes, seconds; 

    void Start()
    {
        tempTime = time + timePenalty; 
        timerText = GetComponent<TextMeshProUGUI>();
    }

    public void penalty(float penalty)
    {
        timePenalty += penalty;
        tempPenalty += penalty;
        if (tempPenalty == 10)
        {
            tempTime += Time.deltaTime + 10;
            tempPenalty = 0;
            Debug.Log("working yes");
        }
    }

    public void timerCount()
    {
        time += Time.deltaTime;
        tempTime += Time.deltaTime; 
        minutes = Mathf.Floor(tempTime / 60).ToString("00");
        seconds = Mathf.Floor(tempTime % 60).ToString("00"); 
        timerText.text = "Time: " + minutes + ":" + seconds;
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
