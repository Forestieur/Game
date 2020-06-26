using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movements : MonoBehaviour
{
   
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    Animator animator;

    [SerializeField]
    private float speedX = 10f;

    [SerializeField]
    private float speedY = 10f;

   

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();


    }


        
    public void FixedUpdate()
    {

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(speedX, rb2d.velocity.y);

           

            spriteRenderer.flipX = true;
        }


        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-speedX, rb2d.velocity.y);
            spriteRenderer.flipX = false;
        }
        else
        {
            
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.Play("idle_anim");
        }




        if (Input.GetKey("w"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, speedY);
           

        }



    }



}