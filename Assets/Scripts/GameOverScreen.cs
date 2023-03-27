using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI endText;
    public TextMeshProUGUI totalTimeText;
    public TextMeshProUGUI gradeText;
    public TextMeshProUGUI highScoreText;
    private float totalTime;
    private float highScore;
    void Start()
    {
        totalTime = Timer.time;
        highScore = PlayerPrefs.GetFloat("LoadHighScore");
    }

    void Update()
    {
        Highscore();
        GradeAndEndText();
        TotalTime();
    }

    private void Highscore()
    {
        if (highScore == 0)
        {
            highScoreText.text = "High Score: " + totalTime.ToString("0.00");
        }
        if (totalTime < highScore)
        {
            highScore = totalTime;
            PlayerPrefs.SetFloat("LoadHighScore", totalTime);
        } 
        highScoreText.text = "High Score: " + highScore.ToString("0.00");
    }

    private void GradeAndEndText()
    {
        if(totalTime <= 20)
        {
            endText.text = "TITLE: GOD GAMER";
            gradeText.text = "GRADE: S"; 
        }
        else if(totalTime >= 20)
        {
            endText.text = "TITLE: GAMER";
            gradeText.text = "GRADE: A";
        }
        else if(totalTime >= 40)
        {
            endText.text = "TITLE: GOOD";
            gradeText.text = "GRADE: B";
        }
        else if (totalTime >= 60)
        {
            endText.text = "TITLE: DECENT";
            gradeText.text = "GRADE: C";
        }
        else if (totalTime >= 80)
        {
            endText.text = "TITLE: MEH";
            gradeText.text = "GRADE: D";
        }
        else if (totalTime >= 100)
        {
            endText.text = "TITLE: NOOB";
            gradeText.text = "GRADE: E";
        }
        else if (totalTime >= 120)
        {
            endText.text = "TITLE: NOOB KING";
            gradeText.text = "GRADE: F";
        }
    }

    private void TotalTime()
    {
        totalTimeText.text = "Total Time: " + totalTime.ToString("0.00"); 
    }

  

}
