using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySlime : MonoBehaviour
{
    public float KBForce; //assigns value for power of knockback
    public float KBCounter; //counts down how much time is left on knockback effect
    public float KBTotalTime; //How long the knockback is altogether

    public bool KnockFromRight; //keeps track of which direction player has been hit from

    [SerializeField] private Rigidbody2D rb; //Used to determine the rigidbody of the Ally Slime Sprite

    private void FixedUpdate()
    {
        if (KBCounter <= 0)
        {
            KBCounter = 0;
        }
        else
        {
            if (KnockFromRight == true) // sends slime to the left when knocked from right
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false) // sends slime to the right when knocked from left
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime; //lowers countdown so knockback doesn't last forever
        }
    }

}
