using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool active = false;
    public bool pressurePlate;
    public Player player;
    private Animator anim; //Used to reference parameters from the animator

    [SerializeField] private AudioSource leverSoundEffect;

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

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && pressurePlate == false)
        {
            leverSoundEffect.Play();
            active = true;
        }

        if(other.gameObject.tag == "Player" && pressurePlate == true)
        {
            if(player.health  > 8)
            {
                leverSoundEffect.Play();
                active =true;
            }
        }
    }

    private void UpdateAnimationState()
    {
        if(active == true)
        {
            anim.SetBool("active", true);
        }

    }

}
