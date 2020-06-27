using System;
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


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        print("distance: " + distToPlayer);

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
        rb2d.velocity = new Vector2(0, 0);
        
    }

    public void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            
        }
        else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            
        }

    }
}