﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakpointE : MonoBehaviour
{
    public GameObject ennemi; // cette variable est initialisé directement dans l'interface d'unity via l'onglet inspector 
    BoxCollider2D BDennemi;
    BoxCollider2D BDplayer;
    GameObject player;
    Rigidbody2D bodyplayer;
    public int health;
  //  public GameObject deatheffect;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        BDennemi = GetComponent<BoxCollider2D>();
        BDplayer = player.GetComponent<BoxCollider2D>();
        bodyplayer = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (BDennemi.IsTouching(BDplayer))
        {
            health--;
            bodyplayer.velocity += new Vector2(0, 2f); //ceci permet  de produire un effet de rebond tout en blessant l'ennemi
            if(health<=0)
            {
              //  Instantiate(deatheffect, transform.position, Quaternion.identity);
                GameObject.Destroy(ennemi);
            }
        }
    }
}