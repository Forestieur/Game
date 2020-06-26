using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Animator animator;
    Object FireballRef;

    void Start()
    {
        FireballRef = Resources.Load("Fireball");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //animator.Play("Player_shooting")
            GameObject fireball = (GameObject)Instantiate(FireballRef);
            fireball.transform.position = new Vector3(transform.position.x + .4f, transform.position.y + .2f, -1);

        }    
        

    }



}