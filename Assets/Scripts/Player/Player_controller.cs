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




    [SerializeField]
    private float speedX = 10f;

    
    
    
    public bool IsFacingleft;

    private bool isShooting;

    private float moveInput;

    public float jumpForce;


    [SerializeField]
    public float shootingDelay = .5f;

    [SerializeField]
    Transform fireball_spawn_pos;

    [SerializeField]
    GameObject fireball;

    
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
        



        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            IsFacingleft = false;

            rb2d.velocity = new Vector2(speedX, rb2d.velocity.y);

            spriteRenderer.flipX = true;
        }


        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            IsFacingleft = true;

            rb2d.velocity = new Vector2(-speedX, rb2d.velocity.y);

            spriteRenderer.flipX = false;
            
        }
        
        else
        {
            
            
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.Play("idle_anim");

        }
        





    }

    void Update()
    {
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
        

    }
    void ResetShoot()
    {
        isShooting = false;
        //animation.Play("Idle")

    }

}