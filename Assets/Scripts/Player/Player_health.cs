using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using UnityEngine;

public class Player_health : MonoBehaviour
{
    

    Rigidbody2D rb2d;
    SpriteRenderer sr;

    [SerializeField]
    private Color defcolor = Color.white;
    [SerializeField]
    private Color hitcolor = Color.red;

    [SerializeField]
    private int health = 1000000;

    [SerializeField]
    private Transform Hit_box_left;
    [SerializeField]
    private Transform Hit_box_left_down;
    [SerializeField]
    private Transform Hit_box_left_up;
    [SerializeField]
    private Transform Hit_box_right;
    [SerializeField]
    private Transform Hit_box_right_up;
    [SerializeField]
    private Transform Hit_box_right_down;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        sr.color = defcolor;
    }


    void Update()
    {
        if (((Physics2D.Linecast(transform.position, Hit_box_left.position, 1 << LayerMask.NameToLayer("enemy")) ||
           Physics2D.Linecast(transform.position, Hit_box_left_down.position, 1 << LayerMask.NameToLayer("enemy")) ||
           Physics2D.Linecast(transform.position, Hit_box_left_up.position, 1 << LayerMask.NameToLayer("enemy"))) && Player_controller.IsFacingleft)
           ||
           ((Physics2D.Linecast(transform.position, Hit_box_right.position, 1 << LayerMask.NameToLayer("enemy")) ||
           Physics2D.Linecast(transform.position, Hit_box_right_down.position, 1 << LayerMask.NameToLayer("enemy")) ||
           Physics2D.Linecast(transform.position, Hit_box_right_up.position, 1 << LayerMask.NameToLayer("enemy"))) && !Player_controller.IsFacingleft)
          )
        {
            health--;
            if (health <= 0)
            {
                Die();
            }
            else
            {
                Hittingcolor();
                rb2d.AddForce(new Vector2(40000, 500));
            }

        }



        if ( ((Physics2D.Linecast(transform.position, Hit_box_right.position, 1 << LayerMask.NameToLayer("enemy")) ||
           Physics2D.Linecast(transform.position, Hit_box_right_down.position, 1 << LayerMask.NameToLayer("enemy")) ||
           Physics2D.Linecast(transform.position, Hit_box_right_up.position, 1 << LayerMask.NameToLayer("enemy"))) && Player_controller.IsFacingleft) 
           ||
           ( (Physics2D.Linecast(transform.position, Hit_box_left.position, 1 << LayerMask.NameToLayer("enemy"))) ||
           (Physics2D.Linecast(transform.position, Hit_box_left_down.position, 1 << LayerMask.NameToLayer("enemy"))) ||
           (Physics2D.Linecast(transform.position, Hit_box_left_up.position, 1 << LayerMask.NameToLayer("enemy")))) && !Player_controller.IsFacingleft)
        {
            health--;
            if (health <= 0)
            {
                Die();
            }
            else
            {
                Hittingcolor();
                rb2d.AddForce(new Vector2(-40000, 500));
            }
        }
        
        
           


        

    }
        private void Otkat() => sr.color = defcolor;
        
        private void Die() => Destroy(gameObject);

        private void Hittingcolor()
        {
        sr.color = hitcolor;
        Invoke("Otkat", .1f);
        }



    
}
