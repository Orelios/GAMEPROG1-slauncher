using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    Image healthBarImage;
    
    public BossMoves boss;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBarImage = GetComponent<Image>();
        //Just make sure the healthBarImage is set to filled type
        healthBarImage.type = Image.Type.Filled;

        //Make sure that the fill amount is set to 1
        healthBarImage.fillAmount = 1;

    }
    
    // Update is called once per frame
    void Update()
    {
        healthBarImage.fillAmount = boss.health / boss.maxHealth;
    }
}