using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthNumber : MonoBehaviour
{
    TextMeshProUGUI text;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "" + player.health;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + player.health ;
    }
}
