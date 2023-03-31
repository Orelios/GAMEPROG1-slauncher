using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMechanism : MonoBehaviour
{
    public Switch playerSwitch;
    public float yMove = -3;
    public float xMove = 6;
    public float moveVelocity = -1;
    public bool horizontal;
    private float desiredYPosition;
    private float desiredXPosition;
    // Start is called before the first frame update
    void Start()
    {
        desiredYPosition = transform.position.y + yMove;
    }

    // Update is called once per frame
    void Update()
    {
        if(yMove < 0 && playerSwitch.active == true && horizontal == false)
        {
            if(transform.position.y > desiredYPosition)
            {
                //transform.position += new Vector3(0, moveVelocity * Time.deltaTime, 0);
                transform.Translate(new Vector2(0.0f, moveVelocity) * Time.deltaTime);
            }
        }
    }
}
