using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimator : MonoBehaviour
{
    private Animator anim; //Used to reference parameters from the animator
    public Switch playerSwitch;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if(playerSwitch.active == true)
        {
            anim.SetBool("active", true);
        }

    }
}
