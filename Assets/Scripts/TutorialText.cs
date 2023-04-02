using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    TextMeshProUGUI text;
    private int tutorialOrder;
    private float blankAfter, blankTimer = 10.0f; //for blanking the text
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Movement (WASD)";
        tutorialOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(tutorialOrder == 1)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                text.text = "Press space to split";
                tutorialOrder += 1;
            }
        }
        if(tutorialOrder == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            text.text = "Press left mouse button to shoot";
            tutorialOrder += 1;
        }
        if(tutorialOrder == 3 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            text.text = "Press 'p' any time to restart (At the cost of added time)";
            tutorialOrder += 1;
        }
        if(tutorialOrder == 4) //has timer to blank the text
        {
            blankTimer = blankAfter;
            if (blankTimer > 0.0f)
            {
                blankTimer -= Time.deltaTime;
            }
            if (blankTimer <= 0.0f)
            {
                text.text = ""; //blanks the text to make it "disappear"
            }
            
        }
    }
}
