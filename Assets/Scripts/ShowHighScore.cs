using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO; 
public class ShowHighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText; 
    private float highScore = 0;
    private string minutes, seconds; 
    SaveHighScore saveHighScore = new SaveHighScore();
    void Start()
    {
        string filePath = Application.dataPath + "/StreamingAssets";
        if (!File.Exists(filePath))
        {
            saveHighScore.highScore = highScore;
            string HighScoreData = JsonUtility.ToJson(saveHighScore);
            string fileDestination = Application.dataPath + "/StreamingAssets";
            File.WriteAllText(fileDestination, HighScoreData);
        }
    }

    private void PrintHighScore()
    {
        string filePath = Application.dataPath + "/StreamingAssets";
        string HighScoreData = File.ReadAllText(filePath);
        saveHighScore = JsonUtility.FromJson<SaveHighScore>(HighScoreData);
        highScore = saveHighScore.highScore;
        minutes = Mathf.Floor(highScore / 60).ToString("00");
        seconds = Mathf.Floor(highScore % 60).ToString("00");
        highScoreText.text = "High Score: " + minutes + ":" + seconds;
    }

    void Update()
    {
        PrintHighScore(); 
    }
}
