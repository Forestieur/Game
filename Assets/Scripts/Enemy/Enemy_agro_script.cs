using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_agro_script : MonoBehaviour
{

    Animator animator;

    [SerializeField]
    Transform player;

    [SerializeField]
    Transform cast_point;

    [SerializeField]
    Transform cast_point_down;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    [SerializeField]
    Transform groundcheck;

    [SerializeField]
    bool IsFacingLeft;

    bool IsGrounded;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
            //print("distance: " + distToPlayer);


        if (Physics2D.Linecast(transform.position, groundcheck.position, 1 << LayerMask.NameToLayer("ground")))
        {
            IsGrounded = true;
        }

        else
        {
            IsGrounded = false;
        }

        if (distToPlayer < agroRange)
        {
            ChasePlayer();

        }
        else
        {

            StopChasingPlayer();
        }   

        if (CanSeePlayer(agroRange))
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }

       
       
    }
    





    bool CanSeePlayer(float distance)
    {
      bool val = false;

      var castDist = distance;

     if(IsFacingLeft == true)
     {
            castDist = -distance;
     }
     
        Vector2 endPos = cast_point.position + Vector3.right * castDist;
        Vector2 endPos_down = cast_point_down.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(cast_point.position, endPos, 1 << LayerMask.NameToLayer("action"));
        RaycastHit2D hit_down = Physics2D.Linecast(cast_point_down.position, endPos_down, 1 << LayerMask.NameToLayer("action"));

        if (hit.collider != null || hit_down.collider != null)
        {
            if(hit.collider.gameObject.CompareTag("Player") || hit_down.collider.gameObject.CompareTag("Player"))
            {
                val = true;

            }
            else
            {
                val = false;
            }

            Debug.DrawLine(cast_point.position, endPos, Color.yellow);
            Debug.DrawLine(cast_point_down.position, endPos_down, Color.yellow);
        }
        else
        {
            Debug.DrawLine(cast_point.position, endPos, Color.white);
            Debug.DrawLine(cast_point_down.position, endPos_down, Color.white);
        }
        
        
        return val;


    }
    
        










    public void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, -10f);
        animator.SetBool("IsWalking", false);
    }

    public void ChasePlayer()
    {
        if(transform.position.x < player.position.x )
        {
            if (IsGrounded == true)
            {
                rb2d.velocity = new Vector2(moveSpeed*1.5f, -10f);
                animator.SetBool("IsWalking", true);
            }
            else
            {
                rb2d.velocity = new Vector2(moveSpeed, 0);
           
            }

            spriteRenderer.flipX = false;
            IsFacingLeft = false;
        }
        else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);

            if (IsGrounded == true)
            {
                rb2d.velocity = new Vector2(-moveSpeed * 1.5f, -10f);
                animator.SetBool("IsWalking", true);
            }

            else
            {
                rb2d.velocity = new Vector2(-moveSpeed, 0); 
             
            }

            spriteRenderer.flipX = true;
            IsFacingLeft = true;
        }

        if (Math.Abs(transform.position.x - player.position.x) < 4f)
        {
            StopChasingPlayer();

        }

    }
}