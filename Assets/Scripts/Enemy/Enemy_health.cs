using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.UI;
using static Health_gen;

public class Enemy_health : MonoBehaviour
{
    
    private int health = Health_gen.enemy_health;

    

    private Color defcolor = Color.white;

    private Color hitcolor = Color.red;

    SpriteRenderer sr;

    [SerializeField]
    public Image bar;

    public float fill;

   


    void Start()
    {
           
        sr = GetComponent<SpriteRenderer>();
        sr.color = defcolor;
       
        float j = (1 / health);
        fill = 1f;
    }
    void Update()
    {

        bar.fillAmount = fill;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("fireball"))
        {
            Destroy(collision.gameObject);
            health--;

            if (health <= 0)
            {

                FindObjectOfType<Sound_manager>().Play("papich_solo");
                Die();
            }
            else
            {
              switch ((new System.Random()).Next(1, 4))
                { 
                    case 1:
                      FindObjectOfType<Sound_manager>().Play("enemy_hit_1");
                    break;
                    case 2:
                      FindObjectOfType<Sound_manager>().Play("enemy_hit_2");
                        break;
                    case 3:
                    FindObjectOfType<Sound_manager>().Play("enemy_hit_3");
                        break;
                }
                sr.color = hitcolor;

                fill -= 0.1f;
                Invoke("Otkat", .1f);
            }
        }

    }

    private void Otkat()
    {
        sr.color = defcolor;
    }


    private void Die()
    {
        Destroy(gameObject);



    }

}
  