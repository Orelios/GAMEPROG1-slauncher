using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerMovement : MonoBehaviour
{
    //Used a youtube video tutorial as a basis: "2D Player Movement In Unity" and "Coyote Time & Jump Buffering In Unity" created by Bendux

    private float horizontal; //Used for the horizontal inputs
    public float moveSpeed = 8f; //Used to determine the speed of the player
    public float jumpingPower = 16f; //Used to determnie the jumping power of the player

    private bool isJumping; //Determines if the player is jumping

    private float coyoteTime = 0.2f; //The max time for coyote time
    private float coyoteTimeCounter; //Determines the counter for coyote time

    private float jumpBufferTime = 0.2f; //The max time for jumpbuffering
    private float jumpBufferCounter; //Determines the counter for jumpbuffering

    [SerializeField] private Rigidbody2D rb; //Used to determine the rigidbody of the Player Sprite
    [SerializeField] private Transform groundCheck; //Used to determine the GroundCheck Object below the player. The object is used to determine if its colliding anything below it
    [SerializeField] private LayerMask groundLayer; //Used to determine which object layer it will check. The object layer that we will use is "Ground"
    [SerializeField] private SpriteRenderer spriteSlauncher; // Used to reference the Slauncher sprite.
    
    private Animator anim; //Used to reference parameters from the animator
    private SpriteRenderer sprite, slauncher; // Used to flip the sprite

    private enum MovementState { idle, running, jumping, falling } //Used to determine the state of the player
    private MovementState state = MovementState.idle; //Assigns state to be idle immediately

    public float KBForce; //assigns value for power of knockback
    public float KBCounter; //counts down how much time is left on knockback effect
    public float KBTotalTime; //How long the knockback is altogether

    public bool KnockFromRight; //keeps track of which direction player has been hit from

    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        slauncher = spriteSlauncher;
    }


    //Updates each frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); //Gets the input of horizontal movement

        if (IsGrounded())//Used to give the player a short window to jump when they leave a platform
        {
            coyoteTimeCounter = coyoteTime;
        }

        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.W))//Used to prevent the player from spamming jumps
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)//Used for high/hold jump
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            jumpBufferCounter = 0f;

            StartCoroutine(JumpCooldown());
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f)//Used for small/tap jump
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }

        UpdateAnimationState();
    }

    private void FixedUpdate()
    {
        if(KBCounter <=0) //movement is only enabled if KBCounter (time of knockback effect) is ended
        {
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);//Calculations and limiter for horizontal movement
            KBCounter = 0;
        }
        else
        {
            if(KnockFromRight == true) // sends player to the left when knocked from right
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false) // sends player to the right when knocked from left
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime; //lowers countdown so knockback doesn't last forever
        }
    }

    //Used to check if it is colliding with a platform that has the "Ground" layer
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //Used to determine the cooldown of the jumps
    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.04f);
        isJumping = false;
    }

    private void UpdateAnimationState() //Checks the state to call the right animation
    {
        MovementState state;

        if(horizontal > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (horizontal < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}