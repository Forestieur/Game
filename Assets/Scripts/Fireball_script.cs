using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Fireball_script : MonoBehaviour
{
    Rigidbody2D rb2d;
   private SpriteRenderer spriteRenderer;
    Animator animator;


    [SerializeField]
    public float fireball_speed = 20;

    [SerializeField]
    int fireballdamage = 20;

    [SerializeField]
    float time_to_destroy = 5;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    public void StartShoot(bool IsFacingleft)
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        if (IsFacingleft)
        {
            
            rb2d.velocity = new Vector2(-fireball_speed, 0);
            spriteRenderer.flipX = true;


        }
        else if(IsFacingleft=true)
        {
            
            rb2d.velocity = new Vector2(fireball_speed, 0);
            

        }

        Destroy(gameObject, time_to_destroy);
    }





}