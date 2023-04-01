using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System; 

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI endText;
    public TextMeshProUGUI totalTimeText;
    public TextMeshProUGUI gradeText;
    public TextMeshProUGUI highScoreText;
    private float totalTime;
    private float highScore;
    string minutes, seconds; 
    SaveHighScore saveHighScore = new SaveHighScore();
    void Start()
    {
        totalTime = Timer.time + Timer.timePenalty;
        string filePath = Application.dataPath + "/StreamingAssets";
        if (!File.Exists(filePath))
        {
            saveHighScore.highScore = totalTime;
            string HighScoreData = JsonUtility.ToJson(saveHighScore);
            string fileDestination = Application.dataPath + "/StreamingAssets";
            File.WriteAllText(fileDestination, HighScoreData);
        }

    }

    void Update()
    {
        loadHighScore();
        Highscore();
        GradeAndEndText();
        TotalTime();
    }

    private void Highscore()
    {     
        if (totalTime < highScore)
        {
            saveHighScore.highScore = totalTime; 
            string HighScoreData = JsonUtility.ToJson(saveHighScore);
            string filePath = Application.dataPath + "/StreamingAssets";
            File.WriteAllText(filePath, HighScoreData);
        }
    }

    private void loadHighScore()
    {
        string filePath = Application.dataPath + "/StreamingAssets";
        string HighScoreData = File.ReadAllText(filePath);
        saveHighScore = JsonUtility.FromJson<SaveHighScore>(HighScoreData);
        highScore = saveHighScore.highScore;
        minutes = Mathf.Floor(highScore / 60).ToString("00");
        seconds = Mathf.Floor(highScore % 60).ToString("00"); 
        highScoreText.text = "High Score: " + minutes+ ":" + seconds;
    }

    private void GradeAndEndText()
    {
        if (totalTime <= 20)
        {
            endText.text = "TITLE: GOD GAMER";
            gradeText.text = "GRADE: S";
        }
        else if (totalTime >= 20)
        {
            endText.text = "TITLE: GAMER";
            gradeText.text = "GRADE: A";
        }
        else if (totalTime >= 40)
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
        minutes = Mathf.Floor(totalTime / 60).ToString("00");
        seconds = Mathf.Floor(totalTime % 60).ToString("00");
        totalTimeText.text = "Total Time: " + minutes + ":" + seconds;
    }
}

