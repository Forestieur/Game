﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_agro_script : MonoBehaviour
{
    [SerializeField]
    Transform player;
    
    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    [SerializeField]
    Transform groundcheck;

    bool IsGrounded;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
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
        print(IsGrounded);
        if (distToPlayer < agroRange)
        {
            ChasePlayer();

        }
        else
        {

            StopChasingPlayer();
        }

       
       
    }

    public void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, -10f);
        
    }

    public void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            if (IsGrounded == true)
            {
                rb2d.velocity = new Vector2(moveSpeed*1.5f, -10f);
            }
            else
            {
                rb2d.velocity = new Vector2(moveSpeed, 0);
            }
            
        }
        else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            if (IsGrounded == true)
            
                rb2d.velocity = new Vector2(-moveSpeed*1.5f, -10f);
            
            else
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            
        }

    }
}