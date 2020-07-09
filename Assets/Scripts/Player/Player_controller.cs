using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player_controller : MonoBehaviour
{
    
    AudioSource audioSrc;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    Animator animator;




    bool IsGrounded;
    public Transform feetpos;
    public float checkRadius;
    public LayerMask whatisground;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;
    public LayerMask whatiswall;

    [SerializeField]
    private float speedX = 10f;

    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    
    
    public static bool IsFacingleft;

    private bool isShooting;

    private float moveInput;

    public float jumpForce;


    [SerializeField]
    public float shootingDelay = .5f;

    [SerializeField]
    Transform fireball_spawn_pos;

    [SerializeField]
    GameObject fireball;
    string LastButton = "A";

    void Start()    
    {
        audioSrc = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d.velocity = new Vector2(moveInput * speedX, rb2d.velocity.y);
        
    }


        
    public void FixedUpdate()
    {




        
        if (LastButton == "A" && Input.GetKey(KeyCode.A))
        {
            IsFacingleft = true;



             moveInput = -1;

             rb2d.velocity = new Vector2(moveInput * speedX, rb2d.velocity.y);
        }
        else if (LastButton == "D" && Input.GetKey(KeyCode.D))
        {
            IsFacingleft = false;



            moveInput = 1;

            rb2d.velocity = new Vector2(moveInput * speedX, rb2d.velocity.y);
        }
        else
        {


            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.Play("idle_anim");

        }
       




    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LastButton = "A";
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            LastButton = "D";
        }

       
        transform.eulerAngles = (moveInput > 0)   ?   new Vector3(0, 180, 0) : new Vector3(0, 0, 0);



        IsGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatisground);


        if (IsGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb2d.velocity = Vector2.up * jumpForce;
            
        }


        if (Input.GetKey(KeyCode.W) && isJumping== true)
        {
            if (jumpTimeCounter > 0)
            {
                rb2d.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }

        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.LeftControl))
        {
            if (isShooting) return;

            //animation.Play("shooting")
            isShooting = true;

            audioSrc.Play();

            GameObject fir = Instantiate(fireball);
            fir.GetComponent<Fireball_script>().StartShoot(IsFacingleft);
            fir.transform.position = fireball_spawn_pos.transform.position;
            Invoke("ResetShoot", shootingDelay);

        }

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatiswall);

        if (isTouchingFront == true && IsGrounded == false && moveInput != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

      //  wallSliding = (isTouchingFront == true && IsGrounded == false && moveInput != 0);

        if (wallSliding)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Clamp(rb2d.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if (Input.GetKeyDown(KeyCode.W) && wallSliding == true)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }
        if (wallJumping == true)
        {
            rb2d.velocity = new Vector2(xWallForce * -moveInput, yWallForce );
        }

    }


    void  SetWallJumpingToFalse()
    {
        wallJumping = false;
        
    }

    void ResetShoot()
    {
        isShooting = false;
        //animation.Play("Idle")

    }
    

}