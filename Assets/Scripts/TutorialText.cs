using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    TextMeshProUGUI text;
    private int tutorialOrder = 1;
    public float blankAfter = 10;
    private float blankTimer; //for blanking the text
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Movement (WASD)";
        blankTimer = blankAfter;
        if (PlayerPrefs.HasKey ("savedTutorialOrder"))
        {
            tutorialOrder = PlayerPrefs.GetInt ("savedTutorialOrder");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //timer starts when game starts, and disappears after set time even if player doesn't follow tutorial
        if (blankTimer > 0)
        {
            blankTimer -= Time.deltaTime;
        }
        if (blankTimer <= 0)
        {
            text.text = ""; //blanks the text to make it "disappear"
            tutorialOrder = 4;
            PlayerPrefs.SetInt("savedTutorialOrder", tutorialOrder);
        }
        
        //if player follows tutorial
        if(tutorialOrder == 1)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                text.text = "Press space to split";
                tutorialOrder += 1;
                PlayerPrefs.SetInt("savedTutorialOrder", tutorialOrder);
            }
        }
        if(tutorialOrder == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            text.text = "Press left mouse button to shoot";
            tutorialOrder += 1;
            PlayerPrefs.SetInt("savedTutorialOrder", tutorialOrder);
        }
        if(tutorialOrder == 3 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            text.text = "Press 'p' any time to restart (At the cost of added time)";
            tutorialOrder += 1;
            PlayerPrefs.SetInt("savedTutorialOrder", tutorialOrder);
        }
        if(tutorialOrder == 4)
        {
            text.text = "";
            PlayerPrefs.SetInt("savedTutorialOrder", tutorialOrder);
        }
    }
}
