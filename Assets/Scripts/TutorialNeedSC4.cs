using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialNeedSC4 : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowText()
    {
        text.text = "2 SC4s needed to destroy barrier";
    }
    public void HideText()
    {
        text.text = " ";
    }
}
