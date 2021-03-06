﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouv : MonoBehaviour
{
    public float speed;
    public float jumphigh;
    public Rigidbody2D rb;
    private bool IsGrounded = false;
    private float x;
    public float X { get { return x; } }
    
    public AudioClip SoundJump; //enleve pas cette ligne

    

    //saut
    void Update()
    {
        if (Input.GetKeyDown("space") && IsGrounded)
        {
            jump();
            GetComponent<AudioSource>().PlayOneShot(SoundJump); // bruit du saut
        }

        float x = Input.GetAxisRaw("Horizontal");
        if (x == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (x == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    public void jump()
    {
        rb.velocity += new Vector2(0, jumphigh);
    }

    //Mouvement gauche/droite
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal")*speed;
        Vector2 rl = new Vector2(moveHorizontal, 0);
        rb.AddForce(rl);
    }

    //Conditions de saut
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("sol"))
        {
            IsGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("sol"))
        {
            IsGrounded = false;
        }
    }

    public bool Grounded { get { return IsGrounded;} }
}
