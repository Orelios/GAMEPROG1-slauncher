using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SC4Text : MonoBehaviour
{
    TextMeshProUGUI text;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        if(player.sc4 == 2)
        {
            text.text = "Return to Shielded Door";
        }
    }
}
