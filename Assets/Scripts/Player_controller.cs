using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player_controller : MonoBehaviour
{
    // Да посмотри ты уже видос про isGrounded, делается за 20 секунд https://www.youtube.com/watch?v=44djqUTg2Sg      30:38
    // Если не сделаешь до того как я проснусь, то сам сделаю :Evilsmailik:
    AudioSource audioSrc;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    Animator animator;

    [SerializeField]
    private float speedX = 10f;

    [SerializeField]
    private float speedY = 10f;
    
    //Все что ниже - для выстрелов, не трогай плез <3 
    public bool IsFacingleft;

    private bool isShooting;


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




        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, speedY);        

        }



    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.LeftControl))
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